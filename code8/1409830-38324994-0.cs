    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                TypeFee tfee = new TypeFee();
                AdminFee addfee = new AdminFee();
                tfee.adminFees = (AdminFee)addfee;
                tfee.adminFees.dollar = addfee.dollar;
            }
        }
        public class Fee
        { 
            public decimal dollar {get;set;} 
            public decimal percentage {get;set;} 
        } 
        public class AdminFee :Fee
        { }
        public class TypeFee
        { 
            public AdminFee adminFees {get;set;}
        }
    }
