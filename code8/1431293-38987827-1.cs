    if (mappingEnabled)
        {
            foreach (GameObject surface in surfaces.Values)
            {
                surface.GetComponent<MeshRenderer>().enabled = DrawVisualMeshes;
            }
    
            if (surfaceWorkOutstanding == false && surfaceDataQueue.Count > 0)
            {
                SurfaceData smsd = surfaceDataQueue.Dequeue();
                if (smsd.outputMesh == null || smsd.outputCollider == null || smsd.outputAnchor == null) { return; }
                {
                    surfaceWorkOutstanding = Observer.RequestMeshAsync(smsd, Observer_OnDataReady);
                }
            }
        }
