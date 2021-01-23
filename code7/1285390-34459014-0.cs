    foreach (DataRow item in StaticTranslate.Rows)
    { 
        var control = this.Page.FindControl(item["ControlName"].ToString());
        var property = control .GetType().GetProperty(item["PropertyName"].ToString());
        property.SetValue(control, item["LocalizedValue"].ToString());
    }
