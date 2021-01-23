      string value = TextBox.Text.Replace(",", "");
      double dbl;
      if (double.TryParse(value, out dbl))
      {
          TextBoxCost.TextChanged -= TextBoxCostTextChanged;
          TextBoxCost.Text = string.Format("{0:#,#0.0000}", dbl); // or {0:#,#0.####}
          TextBoxCost.SelectionStart = TextBoxCost.Text.Length;
          TextBoxCost.TextChanged += TextBoxCostTextChanged;
      }
