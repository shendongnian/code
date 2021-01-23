    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Pet
        {
            protected string name;
            public Pet(String name)
            {
                this.name = name;
            }
    
        }
    
        class Dog : Pet
        {
            private List<String> tricks;
            public Dog(String name, List<String> tricks):base(name)
            {
                this.tricks = tricks;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<string> tricks = new List<string>();
                tricks.Add("sit");
                tricks.Add("jump");
                tricks.Add("bark");
                Dog puppy = new Dog("Fido", tricks);
            }
        }
    }
