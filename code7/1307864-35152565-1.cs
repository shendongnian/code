    public Nullable<bool> Recurring { get; set; }
    public string RecurringText
    { get { 
            if(Recurring.HasValue && Recurring.Value == true)
               return "Yes";
            else
               return "No";
           }
    }
