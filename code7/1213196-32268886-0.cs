    public DateTime BookDate
            {
                get
                {
                   DateTime dt = DateTime.MinValue;//you default datetime here
                   DateTime.TryParse(Convert.ToString(this.PXP.BookDate.Value),out dt)
                   return dt;  
    
                }
        }
