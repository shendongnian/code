    public partial class Planification
    {
        public Profile Creator 
        { 
            get{ return this.Profile1; }
            set{
                this.Profile1 = value;
            } 
        }
    
        public Profile Guest 
        { 
            get{ return this.Profile; }
            set{
                this.Profile = value;
            } 
        }
    }
