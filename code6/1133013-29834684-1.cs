    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WpfTests
    {
        class ViewModel
        {
            public List<Models> ItemList
            {
                get
                {
                    return new List<Models>()
                    {
                        new Models(),
                        new Models()
                    };
                }
            }
        }
    
        class Models
        {
            public string Name { get { return "test"; } }
            public string ImagePath { get { return "image"; } }
    
            public List<Person> Good
            {
                get
                {
                    return new List<Person>()
                    {
                        new Person() {Name = "Name"},
                        new Person() {Name = "Name"},
                        new Person() {Name = "Name"}
                    };
                }
            }
    
            public List<Person> Bad
            {
                get
                {
                    return new List<Person>()
                {
                    new Person() {Name = "Name"}
                };
                }
            }
        }
    
        class Person
        {
            public string Name { get; set; }
            public string ImagePath { get; set; }
        }
    }
