    public class RowObject
    {
        public DateTime date;
        public string price;
        public bool IsValid()
        {
            if (date == null)
            {
                // Maybe output a warning to console here
                return false;
            }
            if (string.IsNullOrEmpty(price))
            {
                // Maybe output a warning to console here
                return false;
            }
            return true;
        }
    }
