    public class Child
    {
        private Parent theOnlyParent;
        private int theOnlyParentId;
        public int Id { get; set; }
        public string NameChild { get; set; }
        [Required]
        public Parent TheOnlyParent
        {
            get
            {
                return theOnlyParent;
            }
            set
            {
                theOnlyParent = value;
                if (value != null)
                    TheOnlyParentId = value.Id;
            }
        }
        public int TheOnlyParentId  
        {
            get { return theOnlyParentId; }
            set { 
                theOnlyParentId = value;
                theOnlyParent = Parent.Create(value);
            }
        }
    }
