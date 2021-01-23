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
                Test test = new Test();
                var list = test.rentalObjects.Select(x => new
                {
                    Name = x.masterDataField.data,
                    AddressName = x.addressField.FirstOrDefault().address,
                    AssociationName = x.associationField.FirstOrDefault().AssociationName,
                    AssociationId = x.associationField.FirstOrDefault().AssociationId
                }).ToList();
            }
        }
        public class Test
        {
            public List<DT_createdRentalObject> rentalObjects { get; set; }
            public Test()
            {
                rentalObjects = new List<DT_createdRentalObject>() {
                    new DT_createdRentalObject() {
                        masterDataField = new SimpleData() { data = "Rafal"},
                        addressField = new Address[] { new Address() {  address = "AFRICA" }},
                        associationField = new Association[] { new Association() {  AssociationName = "TS",   AssociationId = "1" }}
                    },
                    new DT_createdRentalObject() {
                        masterDataField = new SimpleData() { data = "Rafal"},
                        addressField = new Address[] { new Address() {  address = "USA" }},
                        associationField = new Association[] { new Association() {  AssociationName = "TA",   AssociationId = "2" }}
                    },
                    new DT_createdRentalObject() {
                        masterDataField = new SimpleData() { data = "Rafal"},
                        addressField = new Address[] { new Address() {  address = "GERMANY" }},
                        associationField = new Association[] { new Association() {  AssociationName = "TS",   AssociationId = "1" }}
                    },
                    new DT_createdRentalObject() {
                        masterDataField = new SimpleData() { data = "Rafal"},
                        addressField = new Address[] { new Address() {  address = "FRANCE" }},
                        associationField = new Association[] { new Association() {  AssociationName = "TA",   AssociationId = "2" }}
                    },
                };
            }
            public partial class DT_createdRentalObject
            {
                public SimpleData masterDataField { get; set; } //-> Name
                public Address[] addressField { get; set; } //-> AddressName
                public Association[] associationField { get; set; } //-> AssociationName, AssociationId
            }
            public class SimpleData
            {
                public string data { get; set; }
            }
            public class Address
            {
                public string address { get; set; }
            }
            public class Association
            {
                public string AssociationName { get; set; }
                public string AssociationId { get; set; }
            }
        }
    }
    ​
