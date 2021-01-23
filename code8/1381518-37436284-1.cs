    public class NumericUpDownCurrency : NumericUpDown
    {
        public NumericUpDownCurrency()
        {
            DecimalPlaces = 2;
            Increment = 1;
            ThousandsSeparator = true;
        }
        protected override void UpdateEditText()
        {
            ChangingText = true;
            var decimalRegex = new Regex(@"(\d+([.,]\d{1,2})?)");
            var m = decimalRegex.Match(Text);
            if (m.Success)
                Text = m.Value;
            ChangingText = false;
            base.UpdateEditText();
            ChangingText = true;
            Text = Value.ToString("C", CultureInfo.CurrentCulture);
        }
    }
