    private void button1_Click(object sender, EventArgs e)
    {
      foreach (SettingsProperty c in Properties.Settings.Default.Properties)
      {
        if (c.DefaultValue[0,0] == 0)
        {
          c.DefaultValue[0, 0] = 1;
        }
      }
    }
