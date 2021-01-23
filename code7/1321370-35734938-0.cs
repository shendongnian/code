    public void addVertices(Vertex[] vertices)
    {
        size = vertices.Length * Vector3.SizeInBytes;
        Vector3[] vertsData = new Vector3[vertices.Length];
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        for (int i = 0; i < vertices.Length; i++)
            vertsData[i] = vertices[i].Position;
        GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)size, vertsData, BufferUsageHint.StaticDraw);
    }
