    var personCmp = new PersonComparer();
    var same = a.SequenceEqual(b, personCmp);
    ...
    class PersonComparer : IEqualityComparer<Person> {
        public bool Equals(Person p1, Person p2) {
            return p1.Name==p2.Name && p1.Age == p2.Age;
        }
        public int GetHashCode(Person p) {
            return p.Name.GetHashCode()*31 + p.Age;
        }
    }
