    public class ProductStatistics
    {
        private int _ExpirationMonth = 3; 
        public int ExpirationMonth
        {
            get
            {
                return _ExpirationMonth;
            }
            set
            {
                _ExpirationMonth = value;
            }
        }
        public IEnumerable<SelectListItem> ExpirationMonthDropdown
        {
            get
            {
                return Enumerable.Range(1, 12).Select(x =>
                    new SelectListItem()
                    {
                        Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                        Value = x.ToString(),
                        Selected = true
                    });
            }
        }
    }
