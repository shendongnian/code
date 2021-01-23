    var p = typeof(DataGrid).GetField("headerFontHeight",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    p.SetValue(dataGrid1, dataGrid1.HeaderFont.Height * 2);
    var m = typeof(DataGrid).GetMethod("OnLayout",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    m.Invoke(dataGrid1, new object[] { null });
    dataGrid1.Invalidate();
