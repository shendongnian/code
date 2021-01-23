    int points = 8;
    var vertices = new VertexPositionColor[points];
    
    for (int x = 0; x < points / 2; x++)
    {
        for (int y = 0; y < 2; y++)
        {
            vertices[(x * 2) + y] = new VertexPositionColor(
                new Vector3(x * 100, y * 100, 0), Color.White);
        }
    }
    var triangleStripIndices = new short[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
      
    GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
        PrimitiveType.TriangleStrip,
        vertices,
        0,          // vertex buffer offset to add to each element of the index buffer
        points,     // number of vertices to draw
        triangleStripIndices,
        0,          // first index element to read
        points - 2  // number of primitives to draw
    );
