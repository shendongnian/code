    public class Animal<SomeAnimal> where SomeAnimal : Walker {
        public SomeAnimal Animal { set; }
        public void Walk() {
             Animal.Walk();
        }
    }
