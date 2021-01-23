    public class Person<T>
    {     
        public T Name;    
    }
    var boolPerson = new Person<bool>();
    boolPerson.Name = true;
    var stringPerson = new Person<string>();
    stringPerson.Name = "aString";
