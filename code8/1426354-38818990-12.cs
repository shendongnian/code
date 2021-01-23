    dtXYZ.Rows.Add(new object[]{10, 3});
    dtXYZ.Rows.Add(new object[]{6, 1});
    dtXYZ.Rows.Add(new object[]{2, 0});
    
    dtXYZ.Rows.Add(dtXYZ.Compute("sum(X)", ""),
                dtXYZ.Compute("sum(Y)", ""));
