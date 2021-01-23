    DataTable dt = new DataTable();
    dt.Columns.Add("Prop", typeof(DateTimeOffset));
    dt.Rows.Add(DateTimeOffset.Now);
    ObjCls cls = new ObjCls();
    cls.Prop = DateTimeOffset.Now;
    object o = DateTime.Now;
    JsonSerializerSettings settings = new JsonSerializerSettings();
    string json1 = JsonConvert.SerializeObject(dt, Formatting.Indented, settings);
    string json2 = JsonConvert.SerializeObject(cls, Formatting.Indented, settings);
