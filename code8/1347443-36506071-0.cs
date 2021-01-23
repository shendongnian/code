    public class Master {
        public int? TotalAmount
        {
            get
            {
                if (Details == null)
                    return null;
                return Details.Sum(c => c.Amount);
            }
        }
        public ICollection<Detail> Details;
    }
