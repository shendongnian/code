    public class PhoneNumber 
    {
        public  PhoneNumber()
        {
             Member = new Dictionary<string, string>();
        }
        
        public  PhoneNumber(string n, string num) : this()
        {            
            Member.Add(n,num);          
        }
        public void Add(string n, string num)
        {
            Member = new Dictionary<string, string>();
            Member.Add(n,num);
        }
        public Dictionary<string,string> Member { get; private set; }
    }
