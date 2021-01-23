    private void button1_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.Properties.Cast<object>()
                                            .Where(c => (int)((SettingsProperty)c).DefaultValue[0, 0] == 0)
                                            .ToList()
                                            .ForEach(c => (int)((SettingsProperty)c).DefaultValue[0, 0] = 1);
      // .ToList() is added because .ForEach() is not available on IEnumerable<T>
      // I added .Cast<object>() to convert from IEnumerable to IEnumerable<object>. Then I use the cast to SettingsProperty so you can use the DefaultValue.
    }
