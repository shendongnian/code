    Array CreateTerrainVertices(float[] _heightmap, float _resolution)
    {
        Debug.Log("Creating terrain vertices");
        // The minimum resolution is 1
        resolution = Mathf.Max(1, resolution);
        Vector2[] vertices = new Vector2[_heightmap.Length * 2];
        // For each point, in the heightmap, create a vertex for
        // the top and the bottom of the terrain.
        for (int i = 0; i < _heightmap.Length; i++)
        {
            vertices[i * 2] = new Vector2(i / resolution, _heightmap[i]);
            vertices[i * 2 + 1] = new Vector2(i / resolution, 0);
        }
        Debug.Log("Created " + vertices.length + " terrain vertices");
        return vertices;
    }
