    class Person
    {
    ...
    enum Genders {Male, Female, NotSet};
    public Genders Gender { get { return Gender; } set { Gender = value; } }
    public Person(string name, int age, string dob, string telNo, Person.Genders gender, string address){...}
    ...
    }
