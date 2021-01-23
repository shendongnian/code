    using (TeradiodeDataContext dc = new TeradiodeDataContext())
    {
        var strDeviceType = "Blade";
        var pluralDeviceType = strDeviceType + "s";
        var devices = (System.Data.Linq.Table<IDeviceTable>)dc.GetType().GetProperty(pluralDeviceType).GetValue(dc);
        var result = from test in dc.Tests
                     join blade in devices on test.DeviceID equals blade.ID
                     select new { test.ID, blade.Name };
    }
