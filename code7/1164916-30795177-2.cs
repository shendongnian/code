    [Equals]
    public class Sent
    {
        public string Address;
        public string Data;
    
        [CustomEqualsInternal]
        bool CustomLogic(Sent other)
        {
            return other.Address == this.Address && other.Data == this.Data;
        }
    
    
        public static implicit operator Sent(Result r)
        {
            return new Sent { Address = r.AddressOK, Data = r.DataOK };
        }        
    }
