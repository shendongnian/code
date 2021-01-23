        public DateTime date;
        public string price;
        public bool IsValid()
        {
            if (date == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(price))
            {
                return false;
            }
            return true;
        }
    }
