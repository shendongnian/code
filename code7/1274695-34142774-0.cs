    public class Person {
        public Person(string eMail, string Name) {
            this.eMail = eMail;
            this.Name = Name;
        }
        public string eMail { get; set; }
        public string Name { get; set; }
    }
    public class eMailKeyedCollection : System.Collections.ObjectModel.KeyedCollection<string, Person> {
        protected override string GetKeyForItem(Person item) {
            return item.eMail;
        }
    }
    
    public void testIt() {
        var testArr = new Person[5];
        testArr[0] = new Person("Jon@Mullen.com", "Jon Mullen");
        testArr[1] = new Person("Jane@Cullen.com", "Jane Cullen");
        testArr[2] = new Person("Jon@Cullen.com", "Jon Cullen");
        testArr[3] = new Person("John@Mullen.com", "John Mullen");
        testArr[4] = new Person("Jon@Mullen.com", "Test Other"); //same eMail as index 0...
    
        var targetList = new eMailKeyedCollection();
        foreach (var p in testArr) {
            if (!targetList.Contains(p.eMail))
                targetList.Add(p);
        }
    }
