    public class A {
        public int ToBeShadowed; //This is a field in the parent class
    }
    public class B : A {
        public void ToBeShadowed(){ //this is a method in the child
            //do something
        }
    }
