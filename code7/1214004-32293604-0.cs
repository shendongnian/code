    public class Child : Parent {
    
        public ChildID { 
            get { return base.Id; }
            set { base.Id = value; }
        }
    
    }
