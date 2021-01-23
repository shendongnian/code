    dtXYZ = new DataTable();
    dtXYZ.Columns.Add("X", typeof(Int32));
    dtXYZ.Columns.Add("Y", typeof(Int32));
    dtXYZ.Columns.Add("Z", typeof(Int32));
    dtXYZ.Columns["Z"].Expression="X+Y";
