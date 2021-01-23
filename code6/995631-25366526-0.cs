    class CustomNumericUpDown : NumericUpDown
    {
        private int currentIndex = 0;
        private decimal[] possibleValues = null;
        public decimal[] PossibleValues
        {
            get
            {
                if (possibleValues == null)
                {
                    possibleValues = GetPossibleValues().ToArray();
                }
                return possibleValues;
            }
        }
        public override void UpButton()
        {
            if (base.UserEdit)
            {
                this.ParseEditText();
            }
            var values = PossibleValues;
            this.currentIndex = Math.Min(this.currentIndex + 1, values.Length - 1);
            this.Value = values[this.currentIndex];
        }
        public override void DownButton()
        {
            if (base.UserEdit)
            {
                this.ParseEditText();
            }
            var values = PossibleValues;
            this.currentIndex = Math.Max(this.currentIndex - 1, 0);
            this.Value = values[this.currentIndex];
        }
        private IEnumerable<decimal> GetPossibleValues()
        {
            foreach (var value in new decimal[] { 1, 2, 3, 4, 6, 12 })
            {
                yield return value;
            }
            for (decimal i = 24; i < Maximum; i += 24)
            {
                yield return i;
            }
        }
    }
