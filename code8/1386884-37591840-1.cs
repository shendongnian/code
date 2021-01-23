      public class Derived: Base {  
        public override string LastName {
          get {
            return String.IsNullOrEmpty(base.LastName)
              ? base.LastName
              : base.LastName.ToUpper(); 
          } 
          set {   
            if (null == value)
              throw new ArgumentNullException("value")
    
            base.LastName = value;
          }
        }
