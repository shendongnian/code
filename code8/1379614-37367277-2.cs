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
                    },
                    QuotesResult = new QuotesResult()
                    {
                        Quotes = new List<Quote>() {
                            new Quote() { Cost = 123, Id = "Package1"},
                            new Quote() { Cost = 123, Id = "Package2"},
                            new Quote() { Cost = 123, Id = "Package3"},
                            new Quote() { Cost = 123, Id = "Package11"},
                            new Quote() { Cost = 123, Id = "Package11"}
                        }
                    }
                };
                var addrQuotes = (from requests in serviceModel.ShippingRequest.Select(x => x.ShippingPackages.Select(y =>  new { address = x.Address, package = y})).SelectMany(z => z)
                                 join quote in serviceModel.QuotesResult.Quotes
                                 on requests.package.Package equals quote.Id
                                 select new { quote = quote, package = requests }).ToList();
                var results = addrQuotes.GroupBy(m => m.package.address)
                   .Select(n => new {
                        quotes = n.Select(c => c).Select(c1 => new {
                         address = c1.package.address,
                         quote = c1.quote
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
            public string Id { get; set; }
            public decimal Cost { get; set; }
        }
    }
