    public class CurrencyTextBox : TextBox
    {
        // Apply currency formatting when text is set from code:
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = Format(RemoveCurrencyFormatting(value));
            }
        }
        // Expose decimal currency value to code:
        public decimal Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private decimal value = 0m;
        // Remove currency formatting dollar signs and commas on focus:
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Text = RemoveCurrencyFormatting(this.Text);
            this.SelectAll();
        }
        // Apply currency formatting when focus is lost:
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Format(this.Text);
        }
        // Perform actual formatting:
        private string Format(string text)
        {
            if (!decimal.TryParse(text, out this.value))
            {
                return value.ToString("C");
            }
            else return string.Empty;
        }
        // Remove currency formatting dollar signs and commas:
        private string RemoveCurrencyFormatting(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value
                    .Replace(NumberFormatInfo.CurrentInfo.CurrencySymbol, string.Empty)
                    .Replace(NumberFormatInfo.CurrentInfo.NumberGroupSeparator, string.Empty);
            }
            else return string.Empty;
        }
    }
