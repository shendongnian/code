    private void DisableIfValueIsTrue()
    {
       foreach (NumericUpDown control in this.Controls.OfType<NumericUpDown>())
       {
         control.Enabled = add1 + add2 == control.Value;
       }
    }
