        public class Person
        {
            public Person() { }
            public string Name { get; set; }
        }
        class Student : Person { }
        class Building<T> : IBuilding<T>
            where T : Person, new()
        {
            public IEnumerable<T> Members { get; set; }
        }
        internal interface IBuilding<out TPerson> where TPerson : Person { }
        class School : Building<Student> { }
        class Container<T>
            where T : IBuilding<Person>, new() { }
     
        class SchoolDistrict : Container<School> { }
