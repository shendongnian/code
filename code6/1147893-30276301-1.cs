        private void SumCurrencies()
        {
            var controls = GetChildControls(this);
            foreach (var control in controls.Where(c => c is ComboBox))
            {
                if (control.Text == "USD")
                {
                    // do something
                }
                else if (control.Text == "GBP")
                {
                    // do something
                }
                else if (control.Text == "EUR")
                {
                    // do something
                }
            }
        }
