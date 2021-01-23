    using System;
    
    class Foo
    {
        static void Main()
        {
            var foo = new Foo();
            foo.Init("abc");
            var person = foo.Model;
            foo.Weight = 123.45M;
            Console.WriteLine(person.Weight); // 123.45
        }
        private Person Model { get; set; }
    
        public void Init(string pId)
        {
            Model = _personService.GetPerson(pId);
        }
    
        public decimal Weight
        {
            get { return Model.Weight; }
            set { Model.Weight = value; }
        }
    }
    public class Person
    {
        public decimal Weight { get; set; }
    }
    static class _personService // yes I know this isn't representative of your setup
    {
        internal static Person GetPerson(string pId)
        {
            return new Person();
        }
    }
