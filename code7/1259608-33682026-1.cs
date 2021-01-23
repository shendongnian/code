    public void GenerateHeightMap() {
        float xStep = size.x / (xRes-1);
        float zStep = size.z / (zRes-1);
        for (int z = 0; z < zRes; z++) {
            for (int x = 0; x < xRes; x++) {
                var xCoord = (float)((size.x * position.x) + x * size.x/xRes) / (xRes - 1);
                var zCoord = (float)((size.z * position.z) + z * size.z/zRes) / (zRes - 1);
                var value = settings.GetModule().GetValue(xCoord, zCoord, 0);
                heights[x, z] = (float)(value / 2f) + 0.5f;
            }
        }
    }
