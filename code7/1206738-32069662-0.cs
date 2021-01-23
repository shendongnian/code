    public DataViewModel(string i)
        {
            int value = 0;
            int.TryParse(i, out value); // TryParse handles the exception itself.
            D = new Data(value);
        }
