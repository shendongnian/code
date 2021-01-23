    public interface ICustomCloning{
        void CopyFrom(ICustomCloning other);
    }
    class Customer: ICustomCloning 
    {
        string Name { get; set; }
        string SSN { get; set; }
        object Addresses { get; set; }
        
        public virtual void CopyFrom(ICustomCloning other){
           if(other is Customer)
           {
               var o = other as Customer;
               //copy values from o. 
               //this.Name = o.Name;
           }
           //else if(other is Addresses)
           //this.Addresses.CopyFrom(other);
        }
    }
    class CustomerData: ICustomCloning 
    {
        string Name { get; set; }
        object Addresses { get; set; }
        
        public virtual void CopyFrom(ICustomCloning other){
           if(other is CustomerDa)
           {
               var o = other as CustomerData;
               //copy values from o. 
               //this.Name = o.Name;
           }
           //else if(other is Addresses)
           //this.Addresses.CopyFrom(other);
        }
    }
    public class Addresses: ICustomCloning{
        public virtual void CopyFrom(ICustomCloning other){
            if(other is Addresses){
                var o as Addresses;
                //Do your copy from o.
            }
        }
    }
