    public void GenerateHeightMap() {
        float xStep = size.x / (xRes-1);
        float zStep = size.z / (zRes-1);
        for (int z = 0; z < size.z; z+=zStep) {
            for (int x = 0; x < size.x; x+=xStep) {
                var xCoord = (float)((size.x * position.x) + x) / (xRes - 1);
                var zCoord = (float)((size.z * position.z) + z) / (zRes - 1);
                var value = settings.GetModule().GetValue(xCoord, zCoord, 0);
                heights[x, z] = (float)(value / 2f) + 0.5f;
            }
        }
    }
