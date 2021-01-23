        class NumericUpdownCustom : NumericUpDown
    {
        private decimal[] possibleValues = null;
        public decimal[] PossibleValues
        {
            get
            {
                return possibleValues;
            }
            set
            {
                possibleValues = value;
                FillDefaultValues();
                this.Value = possibleValues.Min();
            }
        }
        public NumericUpdownCustom() : base()
        {
            FillDefaultValues();
            this.Value = PossibleValues.Min();    
        }
        private void FillDefaultValues() {
            if (PossibleValues == null) {
                List<decimal> items = new List<decimal>();
                for (decimal i = this.Minimum; i <= this.Maximum; i++)
                {
                    items.Add(i);
                }
                PossibleValues = items.ToArray();
            }
        }
        public override void UpButton()
        {
            if (base.UserEdit)
            {
                this.ParseEditText();
            }
            decimal number = (decimal)this.Value;
            if (PossibleValues.Any(a => a > number))
            {
                this.Value = PossibleValues.Where(w => w > number).Min();
            }
            else
            {
                this.Value = PossibleValues.Max();
            }
        }
        public override void DownButton()
        {
            if (base.UserEdit)
            {
                this.ParseEditText();
            }
            decimal number = (decimal)this.Value;
            if (PossibleValues.Any(a => a < number))
            {
                this.Value = PossibleValues.Where(w => w < number).Max();
            }
            else
            {
                this.Value = PossibleValues.Min();
            }
        }
        public new decimal Value
        {
            get
            {
                decimal desiredValue = base.Value;
                if (!PossibleValues.Contains(desiredValue))
                {
                    var nearest = PossibleValues.Aggregate((current, next) => Math.Abs((long)current - desiredValue) < Math.Abs((long)next - desiredValue) ? current : next);
                    SetValueWithoutRaisingEvent(nearest);
                }
                return base.Value;
            }
            set
            {
                if (!PossibleValues.Contains(value))
                {
                    var nearest = PossibleValues.Aggregate((current, next) => Math.Abs((long)current - value) < Math.Abs((long)next - value) ? current : next);
                    base.Value = nearest;
                }
                else
                {
                    if (value < this.Minimum)
                    {
                        base.Value = this.Minimum;
                    }
                    else if (value > this.Maximum)
                    {
                        base.Value = this.Maximum;
                    }
                    else
                    {
                        base.Value = value;
                    }
                }
            }
        }
        private void SetValueWithoutRaisingEvent(decimal value) {
            var currentValueField = GetType().BaseType.GetRuntimeFields().Where(w => w.Name == "currentValue").FirstOrDefault();
            if (currentValueField != null)
            {
                currentValueField.SetValue(this, value);
                this.Text = value.ToString();
            }
        }
    }
