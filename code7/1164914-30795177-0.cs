    using System;    
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            var a = new Sent { Address = "04004C", Data = "55AA55" };
            var b = new Sent { Address = "04004C", Data = "55AA55" };
    
            Console.WriteLine(a.Equals(b)); // True with use of an AOP, False with no AOP                    
            var sent = new List<Sent>() {
    			new Sent { Address = "04004C", Data = "55AA55" },
    			new Sent { Address = "040004", Data = "0720" },				
    			new Sent { Address = "040037", Data = "31" },				
    			new Sent { Address = "04004A", Data = "FFFF" }
    		};
   
            var res = new List<Result>() {
    			new Result { AddressOK = "04004C", DataOK = "55AA55" },
    			new Result { AddressOK = "040004", DataOK = "0721" },				
    			new Result { AddressOK = "040038 ", DataOK = "31" },				
    			new Result { AddressOK = "04004A", DataOK = "FFFF" }    
    		};
    
               
            var diff =
                sent.Except(res.Select(r => new Sent { Address = r.AddressOK, Data = r.DataOK }));
    
            foreach (var item in diff)
                Console.WriteLine("{0} {1}", item.Address, item.Data);           
    
        }
    }
    
    
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
    }
    
    public class Result
    {
        public string AddressOK;
        public string DataOK;
    }
