    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication93
    {
        class Program
        {
            static void Main(string[] args)
            {
                var v = StreetAddress.addresses.GroupBy(x => x);
            }
        }
        class StreetAddress : IComparable
        {
            public static List<StreetAddress> addresses { get; set; }
            public string street { get; set; }
            public int houseNumber { get; set; }
            public StreetAddress() { ; }
            public StreetAddress(string _street, int _houseNumber)
            {
                StreetAddress newAddress = new StreetAddress();
                addresses.Add(newAddress);
                newAddress.street = _street;
                newAddress.houseNumber = _houseNumber;
            }
            public int CompareTo(object _other)
            {
                int results = 0;
                StreetAddress other = (StreetAddress)_other;
                if (this.street != other.street)
                {
                    results = this.street.CompareTo(other.street);
                }
                else
                {
                    results = this.houseNumber.CompareTo(other.houseNumber);
                }
                return results;
            }
        }
     
    }
