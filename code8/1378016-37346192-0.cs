    public void SetModel(Vector3[] modelVertices, int[] modelFaces, Vector2[] modelUV)
        {
            _model = new VBO<Vector3>(modelVertices);
            _modelFaces = new VBO<int>(modelFaces, BufferTarget.ElementArrayBuffer);
            _modelUV = new VBO<Vector2>(modelUV, BufferTarget.TextureBuffer);
        }
