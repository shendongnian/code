    protected void ColorDeviceListItems(object sender, EventArgs e)
    {
        if (DeviceObjectDDL.DataSource == null) return;
        var disabledList = ((List<Device>)(DeviceObjectDDL.DataSource).FindAll(d => !d.Active || !d.Visible);
        
        foreach (var device in disabledList)
        {
            var item = DeviceObjectDDL.Items.FindByValue(device.ID.ToString());
            if (item == null) continue;
            if ((!device.Active) && (!device.Visible))
                item.Attributes.CssStyle.Add("color", "Purple");
            else
            {
                if (!device.Active)
                    item.Attributes.CssStyle.Add("color", "Blue");
                if (!device.Visible)
                    item.Attributes.CssStyle.Add("color", "#8B0000");
            }
        }
    }
