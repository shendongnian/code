    class Person {
        public Int32 Age;
    }
    ////
    Person p = new Person() { Age = 25; }
    Int32? age = p.Age.If( pv => pv < 55 && pv > 60 );
