        private void CustomEntry_Unfocused(object sender, FocusEventArgs e)
        {
            try
            {
                //If the user leaves the field empty, we set the last value
                BasketProduct bp = (BasketProduct)BindingContext;
                if (this.Text.Trim().Equals(string.Empty))
                {
                    this.Text = bp.NumElements.ToString();
                }
            }
            catch (FormatException ex) { }
        }
