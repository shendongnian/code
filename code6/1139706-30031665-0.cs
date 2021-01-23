    Dictionary<string, double> dictionaryValues = new Dictionary<string, double>();
    private void Form1_Load(object sender, EventArgs e)
    {
      comboBoxApplicances.Items.Add("Air conditioning");
      comboBoxApplicances.Items.Add("Attic fan");
      comboBoxApplicances.Items.Add("Ceiling fan");
      comboBoxApplicances.Items.Add("Dishwasher");
      comboBoxApplicances.SelectedIndex = 0;
      dictionaryValues.Add("Air conditioning", 0);
      dictionaryValues.Add("Attic fan", 0);
      dictionaryValues.Add("Ceiling fan", 0);
      dictionaryValues.Add("Dishwasher", 0);
      for (int i = 0; i < 24; i++)
      {
        comboBoxHours.Items.Add(i < 10 ? "0" + i : i.ToString()); // add 0 for i < 10
      }
      comboBoxHours.SelectedIndex = 0;
      comboBoxMinutes.Items.Add("00");
      comboBoxMinutes.Items.Add("15");
      comboBoxMinutes.Items.Add("30");
      comboBoxMinutes.Items.Add("45");
      comboBoxMinutes.SelectedIndex = 0;
    }
    private void buttonCompute_Click(object sender, EventArgs e)
    {
      // adding value to the selected appliance
      dictionaryValues[comboBoxApplicances.SelectedItem.ToString()] +=
        GetHoursMinutes(comboBoxHours.SelectedItem.ToString(),
        comboBoxMinutes.SelectedItem.ToString());
      labelCurrentApplicance.Text = dictionaryValues[comboBoxApplicances.SelectedItem.ToString()].ToString();
    }
    private double GetHoursMinutes(string hours, string minutes)
    {
      double result = 0;
      double minutesB60 = double.Parse(minutes);
      double minutesB10 = (minutesB60 / 60);
      result = double.Parse(hours) + minutesB10;
      return result;
    }
