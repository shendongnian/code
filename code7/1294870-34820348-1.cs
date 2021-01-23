    static void FixImageOrientation(Image srce) {
        const int ExifOrientationId = 0x112;
        // Read orientation tag
        if (!srce.PropertyIdList.Contains(ExifOrientationId)) return;
        var prop = srce.GetPropertyItem(ExifOrientationId);
        var orient = BitConverter.ToInt16(prop.Value, 0);
        // Force value to 1
        prop.Value = BitConverter.GetBytes((short)1);
        srce.SetPropertyItem(prop);
        // Rotate/flip image according to <orient>
        switch (orient) {
            // etc...
        }
    }
