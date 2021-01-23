    	Vertex[] vertices = // Fill some vertices here..
        // This is workaround that i was talking about, de-interleave attributes of Vertex Struct
        // it might be better to de-interleaving those attributes when the vertices has been changed rather than de-interleaving them each frames.
        List<Vector2> positions = new List<Vector2>();
        foreach (Vertex v in vertices)
            positions.Add(v.position);
        List<Vector2> texCoords = new List<Vector2>();
        foreach (Vertex v in vertices)
            texCoords.Add(v.texCoords);
        List<Vector4> colors = new List<Vector4>();
        foreach (Vertex v in vertices)
            colors.Add(v.color);
        // Since we de-interleaved those attributes, we must provide the attributes stride rather than the Vertex stride.
        GL.VertexPointer(2, VertexPointerType.Float, Vector2.SizeInBytes, positions.ToArray());
        GL.TexCoordPointer(2, TexCoordPointerType.Float, Vector2.SizeInBytes, texCoords.ToArray());
        GL.ColorPointer(4, ColorPointerType.Float, Vector4.SizeInBytes, colors.ToArray());
        // Draw the Vertices
        GL.DrawArrays(PrimitiveType.Quads),
            0,
            vertices.length);
