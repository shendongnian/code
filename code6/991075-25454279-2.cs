    foreach(PropertyDescriptor pd in TypeDescriptor.GetProperties(src)) {
        if(!pd.ShouldSerializeValue(src)) {
            if(src is DataGridView && pd.Name == "Rows")
                CopyDataGridRows((DataGridView)src, (DataGridView)dst);
            continue; }
