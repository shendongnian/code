    class Person{
        string name location;
        Gender gender;
        int age;
        public Person(string name, int age, string location = null, Gender gender = null){
            // set fields
            // location is optional so it might be null.
            // Gender can be an object or an enum type.
        }
    }
    class NewAccount{
        String email, password;
    }
    class Order{
        String OrderType = null;
    }
