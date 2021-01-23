    public class MyClass
    {
        private MyField myField;
        public MyClass() {
            myField = new MyField();
        }
        public int myMethod(int b) {
            return myField.SomeMethod(b);
        }
    }
    public class MyField
    {
        public int SomeMethod(int i) {
            return i;
        }
    }
