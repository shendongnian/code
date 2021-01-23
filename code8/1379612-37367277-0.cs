    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ServiceModel serviceModel = new ServiceModel()
                {
                    ShippingRequest = new List<ShippingRequest>(){
                        new ShippingRequest() {
                            Address = "Address 1",
                            ShippingPackages = new List<ShippingPackage>() {
                                new ShippingPackage() { Package = "Package1"}, 
                                new ShippingPackage() { Package = "Package2"}, 
                                new ShippingPackage() { Package = "Package3"}
                            }
                        },
                        new ShippingRequest() {
                            Address = "Address 2",
                            ShippingPackages = new List<ShippingPackage>() {
                                new ShippingPackage() { Package = "Package5"}, 
                                new ShippingPackage() { Package = "Package8"}, 
                            }
                        },
                        new ShippingRequest() {
                            Address = "Address 3",
                            ShippingPackages = new List<ShippingPackage>() {
                                new ShippingPackage() { Package = "Package11"}, 
                                new ShippingPackage() { Package = "Package12"}, 
                            }
                        }
                    }
                };
                var addrQuotes = serviceModel.ShippingRequest
                    .GroupBy(m => m.Address)
                    .Select(n => new {
                        quotes = n.Select(c => c).Select(c1 => new {
                          c1 = c1.Address,
                          c2 = c1.ShippingPackages.Select(c3 => c3.Package).ToList()
                        }).ToList()
                    }).ToList();
                                
            }
        }
        public class ServiceModel
        {
            public List<ShippingRequest> ShippingRequest { get; set; }
            public QuotesResult QuotesResult { get; set; }
        }
        public class ShippingRequest
        {
            public string Address { get; set; }                    // AddressId
            public List<ShippingPackage> ShippingPackages { get; set; }
        }
        public class ShippingPackage
        {
            public string Package { get; set; }                    // PackageId
            public List<string> ShippingItems { get; set; }  // IsSkipped
        }
        public class QuotesResult
        {
            public List<Quote> Quotes { get; set; } // PackageId, Cost
        }
        public class Quote
        {
            public int Id { get; set; }
            public decimal Cost { get; set; }
        }
    }
