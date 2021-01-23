    var genericPanel = new Panel();
    var myName = "panel" + 3;
    PropertyInfo prop = genericPanel.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
    if (null != prop && prop.CanWrite)
    {
        prop.SetValue(genericPanel, myName, null);
    }
    genericPanel.Enabled = true;
    genericPanel.Visible = true;
    genericPanel.BackColor = Color.Red;
           
    this.Controls.Add(genericPanel);
