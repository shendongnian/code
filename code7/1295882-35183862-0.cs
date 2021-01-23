        public void PerformSmoothVertexSkinning()
        {
            // Precompute final transformation matrix for each bone
            List<Matrix4x4> FinalTransforms = new List<Matrix4x4>();
            foreach (ModelBone bone in this.BoneHierarchy.Bones)
            {
                // Multiplying a vector (e.g. vertex position/normal) by finalTransform will (from right to left):
                //      1. transform the vector from mesh space to bone space (by bone.Offset)
                //      2. transform the vector from bone space to world space (by bone.GlobalTransform)
                Matrix4x4 finalTransform = bone.GlobalTransform * bone.Offset;
                finalTransform.Transpose();
                FinalTransforms.Add(finalTransform);
            }
            foreach (Submesh submesh in this.Submeshes)
            {
                foreach (Vertex vertex in submesh.Vertices)
                {
                    Vector3D newPosition = new Vector3D();
                    Vector3D newNormal = new Vector3D();
                    for (int i = 0; i < vertex.BoneIndices.Length; i++)
                    {
                        int boneIndex = vertex.BoneIndices[i];
                        float boneWeight = vertex.BoneWeights[i];
                        // Get final transformation matrix to transform each vertex position
                        Matrix4x4 finalVertexTransform = FinalTransforms[boneIndex];
                        // Get final transformation matrix to transform each vertex normal (has to be inverted and transposed!)
                        Matrix4x4 finalNormalTransform = FinalTransforms[boneIndex];
                        finalNormalTransform.Inverse();
                        finalNormalTransform.Transpose();
                        // Calculate new vertex position and normal (average of influencing bones)
                        // Formula: newPosition += boneWeight * (finalVertexTransform * vertex.OriginalPosition);
                        //                      += boneWeight * (bone.GlobalTransform * bone.Offset * vertex.OriginalPosition);
                        // From right to left:
                        //      1. Transform vertex position from mesh space to bone space (by bone.Offset)
                        //      2. Transform vertex position from bone space to world space (by bone.GlobalTransform)
                        //      3. Apply bone weight
                        newPosition += boneWeight * (finalVertexTransform * vertex.OriginalPosition);
                        newNormal += boneWeight * (finalNormalTransform * vertex.OriginalNormal);
                    }
                    // Apply new vertex position and normal
                    vertex.Position = newPosition;
                    vertex.Normal = newNormal;
                }
            }
        }
