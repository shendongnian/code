    public string PersonName 
    {
        get 
        {
            return (this.person == null) ? String.Empty : this.person.ToString();
        }
    }
