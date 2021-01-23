    public class YourBindableItem
    {
        public decimal OriginalValue { get; set; }
        public decimal ParsedValue 
        {
            get { return this.OriginalValue.ToString(); }
            set
            {
                string forParse = 
                    value.Replace(",", Globalization.CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
                decimal temp = 0;
                if(decimal.TryParse(forParse, 
                                    out temp,
                                    Globalization.CultureInfo.InvariantCulture) == true)
                {
                    this.OriginalValue = temp;
                }
                //if value wasn't parsed succesfully, original value will be returned
                this.RaiseOnPropertyChanged(nameOf(this.ParsedValue));
            }
        }
    }
