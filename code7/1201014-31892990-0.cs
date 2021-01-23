    public class parent_class
        {
            public virtual string common_method()
            {
                //dynamic child =  /* something to access the derived class */ ;
    
                if (this.GetType() == typeof(parent_class))
                    return typeof(parent_class).FullName;
                else
                    return this.GetType().FullName;
            }
        }
    
        public class child_class1 : parent_class { }
        public class child_class2 : parent_class { }
        public class child_class3 : parent_class { }
