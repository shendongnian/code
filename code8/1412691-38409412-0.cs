      string value = TextBox.Text.Replace(",", "");
      double dbl;
      if (double.TryParse(value, out dbl))
      {
          TextBoxCost.TextChanged -= TextBoxCostTextChanged;
          TextBoxCost.Text = string.Format("{0:#,#0}", dbl);
          TextBoxCost.SelectionStart = TextBoxCost.Text.Length;
          TextBoxCost.TextChanged += TextBoxCostTextChanged;
      }
