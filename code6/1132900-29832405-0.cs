    public partial class PhoneNumber
    {
        public int Ordinal;
        public int Port;
        public string Phone;
        public string IPaddress;
    
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
    
            PhoneNumber pn = obj as PhoneNumber;
            if ((object)pn == null)
            {
                return false;
            }
            return (this.Ordinal == pn.Ordinal) && (this.Port == pn.Port) && (this.Phone == pn.Phone) && (this.IP == pn.IP); 
        }
    }
