    public class HalfHourNumericUpDown : NumericUpDown
    {
        public HalfHourNumericUpDown()
        {
            this.DecimalPlaces = 1;
        }
        public override void UpButton()
        {
            if (this.Value <= this.Maximum - (decimal).5)
                this.Value = this.Value + (decimal).5;
            else
                this.Value = this.Maximum;
            this.RoundToHalf();
        }
        public override void DownButton()
        {
            if (this.Value >= (decimal).5)
                this.Value = this.Value - (decimal).5;
            else
                this.Value = this.Minimum;
            this.RoundToHalf();
        }
        protected override void UpdateEditText()
        {
            base.UpdateEditText();
            this.RoundToHalf();
        }
        private void RoundToHalf()
        {
            decimal value = this.Value;
            value = value * 2;
            value = Math.Round(value, MidpointRounding.AwayFromZero);
            value = value / (decimal)2;
            this.Value = Math.Min(this.Maximum, Math.Max(value, this.Minimum));
        }
    }
