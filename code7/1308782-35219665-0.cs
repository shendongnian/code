    CivilDocument civilDoc = CivilApplication.ActiveDocument;
    using (Transaction tr = db.TransactionManager.StartTransaction())
    {
        // Open for write
        TinSurface modSurface = tr.GetObject(this.createdSurfaceId, OpenMode.ForWrite) as TinSurface;
        foreach (VertexGroup group in this.verticeCollection)
        {
            // Populate a list of all vertices to run
            List<TinSurfaceVertex> runVertices = new List<TinSurfaceVertex>();
            // Try this
            foreach (KeyValuePair<string, Point3d> keyVal in group.ContainedVerticePoints)
            {
                string key = keyVal.Key;
                if (!usedVertices.ContainsKey(key))
                {
                    // Re-fetch the vertex at xy
                    // THIS IS THE MAGIC
                    TinSurfaceVertex vtx = modSurface.FindVertexAtXY(keyVal.Value.X, keyVal.Value.Y);
                    // Add it to the vertexes to update
                    runVertices.Add(vtx);
                    usedVertices.Add(key, vtx);
                }
            }
            // Only modify if not already modified
            if (runVertices.Count > 0)
            {
                // Modify the vertices
                modSurface.SetVerticesElevation(runVertices, 0.0);
            }
        }
        // Commit the transaction
        tr.Commit();
    }
