    if (mappingEnabled)
        {
            foreach (GameObject surface in surfaces.Values)
            {
                surface.GetComponent<MeshRenderer>().enabled = DrawVisualMeshes;
            }
    
            if (surfaceWorkOutstanding == false && surfaceDataQueue.Count > 0)
            {
                SurfaceData smsd = surfaceDataQueue.Dequeue();
                if(smsd != null)
                {
                    surfaceWorkOutstanding = Observer.RequestMeshAsync(smsd, Observer_OnDataReady);
                }
            }
        }
