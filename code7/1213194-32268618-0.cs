    public DateTime BookDate
        {
            get
            {
                if (this.PXP.BookDate.HasValue)
                {
                    return this.PXP.BookDate.Value;
                }
                else return "";
            }
        }
