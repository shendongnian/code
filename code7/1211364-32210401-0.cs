    public DateTime? EntryDateValue
    {
        get
        {
            DateTime dateValue;
            if (DateTime.TryParse(EntryDate, out dateValue))
                return dateValue;
            return null;
        }
        set
        {
            // parse "value" to the string format you want
            // and store it in EntryDate
        }
    }
