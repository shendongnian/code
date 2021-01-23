    private void button1_Click(object sender, EventArgs e)
    {
      Properties.Settings.Default.Properties.Where(c => c.DefaultValue[0, 0] == 0).ToList().ForEach(c => c.DefaultValue[0, 0] = 1);
      // .ToList() is added because .ForEach() is not available on IEnumerable
    }
