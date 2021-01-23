    public partial class MyTable
    {
        [NotMapped]
        public string DayOfWeek
        { 
            get 
            { 
                if (Date.HasValue)
                    return DateTime.Now.DayOfWeek.ToString();
                else
                    return null;
            } 
        }
    }
