    public string Error
    {
        get
        {
            StringBuilder errors = new StringBuilder();
            foreach (string error in Errors) errors.AppendUniqueOnNewLineIfNotEmpty(error);
            return errors.ToString();
        }
    }
    public override ObservableCollection<string> Errors
    {
        get
        {
            errors = new ObservableCollection<string>();
            errors.AddUniqueIfNotEmpty(this["Property1"]);
            errors.AddUniqueIfNotEmpty(this["Property2"]);
            errors.AddUniqueIfNotEmpty(this["PropertyN"]);
            errors.AddRange(ExternalErrors);
            return errors;
        }
    }
