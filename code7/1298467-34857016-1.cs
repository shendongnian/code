        public class Customer
        {
                public String Login{get;set;}
                public String FIO{get;set;}
        }
    
        public class Phone{
                public String Code{get;set;}
                public String Number{get;set;}
        }
    
        public class Address{
                public String CityName{get;set;}
                public String StationName{get;set;}
                public String StreetName{get;set;}
                public String House{get;set;}
                public String Corpus{get;set;}
                public String Building{get;set;}
                public Int32 Flat{get;set;}
                public String Porch{get;set;}
                public Int32 Floor{get;set;}
                public String DoorCode { get; set; }
        }
    
        public class Order
        {
                public Int32 CallConfirm {get;set;}
                public String PayMethod{get;set;}
                public String QtyPerson{get;set;}
                public Int32 Type {get;set;}
                public Int32 PayStateID {get;set;}
                public String Remark {get;set;}
                public Int32 RemarkMoney {get;set;}
                public String TimePlan {get;set;}
                public Int32 Brand {get;set;}
                public Int32 DiscountPercent {get;set;}
                public Int32 BonusAmount {get;set;}
                public String Department {get;set;}
    
                public Customer Customer  {get;set;}
                public Address Address {get;set;}
                public Phone Phone { get; set; }
                public List<String> Products { get; set; }
        } 
    
           static void Main(string[] args)
            {
                var order = new Order()
                {
                    Address = new Address()
                    {
                        CityName = "Yeah"
                    },
                    Phone = new Phone()
                    {
                        Code = "251"
                    },
                    Customer = new Customer()
                    {
                        FIO = "Lev Leshenko"
                    },
                    CallConfirm = 1
                    //...
                };
    
                var s = new XmlSerializer(typeof(Order));
                using(var f = File.Open("test.xml",FileMode.Create)){
                    s.Serialize(f, order);
                }
            }
