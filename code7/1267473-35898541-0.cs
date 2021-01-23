     class Program
        {
            static void Main(string[] args)
            {
                IList<Carrier> CarrierList = new List<Carrier>();
                CarrierList.Add(new Carrier { CarrierId = 1, Name = "A", Description = "AA", ParentCarrierId = null });
                CarrierList.Add(new Carrier { CarrierId = 2, Name = "B", Description = "BB", ParentCarrierId = 1 });
                CarrierList.Add(new Carrier { CarrierId = 3, Name = "C", Description = "CC", ParentCarrierId = 1 });
                CarrierList.Add(new Carrier { CarrierId = 4, Name = "D", Description = "DD", ParentCarrierId = 3 });
                CarrierList.Add(new Carrier { CarrierId = 5, Name = "E", Description = "EE", ParentCarrierId = null });
                Temp temp = new Temp();
            IList<Carrier> CarrierList1=new List<Carrier>(); 
                 foreach (Carrier carrier in CarrierList.Where(p => p.ParentCarrierId == null).ToList() )
                {
                    CarrierList1.Add(temp.Recursive(carrier, CarrierList));
                }
            }
        }
        public class Temp
        {
            public Carrier Recursive(Carrier carrier,IList<Carrier> carrierList)
            {
               
                if (carrierList.Where(c => c.ParentCarrierId == carrier.CarrierId).Count() <1)
                {
                    return carrier ;
                }
                else
                {
                    IList<Carrier> newList = new List<Carrier>();
                    foreach (Carrier ca in carrierList.Where(c => c.ParentCarrierId == carrier.CarrierId)){
                        newList.Add(Recursive(ca, carrierList));
                }
                    carrier.CarrierList = newList;
                    return carrier;
                }
            }
        }
        public class Carrier
        {
            public int CarrierId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int? ParentCarrierId { get; set; }
            public IList<Carrier> CarrierList { get; set; }
        }
    }
