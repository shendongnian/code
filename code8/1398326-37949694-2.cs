    public class AlreadyMade
    {
        public int ListOfOrgs { get; set; }
    
        public override bool Equals(object obj)
        {
            var item = (int?)obj;
    
            if (item == null)
            {
                return false;
            }
    
            return this.ListOfOrgs.Equals(item.Value);
        }
    }
