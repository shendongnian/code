    public string PersonName 
    {
        get 
        {
            return (this.person == null) ? String.Empty : this.person.ToString();
        }
        set
        {
            if(this.person == null)
            {
                this.person = new Person(value, 0);
            }
            else
            {
                this.person.Name = value;
            }
        }
    }
