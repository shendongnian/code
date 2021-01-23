    primitiveList = new VertexPositionColor[points];
    
    for (int x = 0; x < points / 2; x++)
    {
        for (int y = 0; y < 2; y++)
        {
            primitiveList[(x * 2) + y] = new VertexPositionColor(
                new Vector3(x * 100, y * 100, 0), Color.White);
        }
    }
     // Initialize an array of indices of type short.
     triangleStripIndices = new short[points];
     
     // Populate the array with references to indices in the vertex buffer.
     for (int i = 0; i < points; i++)
     {
         triangleStripIndices[i] = (short)i;
     }
     triangleStripIndices = new short[8]{ 0, 1, 2, 3, 4, 5, 6, 7 };
 
     for (int i = 0; i < primitiveList.Length; i++)
     {
         primitiveList[i].Color = Color.Red;
     }
     
     GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
         PrimitiveType.TriangleStrip,
         primitiveList,
         0,  // vertex buffer offset to add to each element of the index buffer
         8,  // number of vertices to draw
         triangleStripIndices,
         0,  // first index element to read
         6   // number of primitives to draw
     );
     for (int i = 0; i < primitiveList.Length; i++)
     {
         primitiveList[i].Color = Color.White;
     }
