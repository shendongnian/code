    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Globalization;
    
    class RangeUpDown : NumericUpDown {
        public decimal LowValue { get; set; }
        public decimal HighValue { get; set; }
    
        private bool lowFocused = true;
        private const string separator = " to ";
    
        protected override void UpdateEditText() {
            if (base.UserEdit) ParseText();
            var lotext = FormatValue(LowValue);
            var hitext = FormatValue(HighValue);
            this.Text = lotext + separator + hitext;
            if (lowFocused) {
                EditBox.SelectionStart = 0;
                EditBox.SelectionLength = lotext.Length;
            }
            else {
                EditBox.SelectionStart = lotext.Length + separator.Length;
                EditBox.SelectionLength = hitext.Length;
            }
            EditBox.Focus();
        }
    
        public override void UpButton() {
            if (base.UserEdit) ParseText();
            if (IsLowValueFocused()) {
                LowValue = Math.Min(this.Maximum, LowValue + this.Increment);
                if (HighValue < LowValue) HighValue = LowValue;
            }
            else {
                HighValue = Math.Min(this.Maximum, HighValue + this.Increment);
            }
            this.OnValueChanged(EventArgs.Empty);
            UpdateEditText();
        }
    
        public override void DownButton() {
            if (base.UserEdit) ParseText();
            if (IsLowValueFocused()) {
                LowValue = Math.Max(this.Minimum, LowValue - this.Increment);
            }
            else {
                HighValue = Math.Max(this.Minimum, HighValue - this.Increment);
                if (LowValue > HighValue) LowValue = HighValue;
            }
            this.OnValueChanged(EventArgs.Empty);
            UpdateEditText();
        }
    
        private bool IsLowValueFocused() {
            lowFocused = EditBox.Text.Substring(EditBox.SelectionStart).Contains(separator.Trim());
            return lowFocused;
        }
    
        private string FormatValue(decimal value) {
            var fmt = (this.ThousandsSeparator ? "N" : "F");
            var frac = this.DecimalPlaces.ToString(CultureInfo.CurrentCulture);
            return value.ToString(fmt + frac, CultureInfo.CurrentCulture);
        }
    
        private TextBox EditBox { get { return (TextBox)Controls[1]; } }
    
        private void ParseText() {
            // Not implemented
            base.UserEdit = false;
        }
    }
