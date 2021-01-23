    public class MyJSON
    {
        public MyJSON(JObject json) { // ...
        public MyJSON(File json) { // ...
        public JObject FirstOption {get; private set;}
        public File SecondOption {get; private set;}
        //TODO some property to indicate which option is valid
    }
    
    public static void MyMethod(MyJSON jsonOne, MyJSON jsonTwo) { // ...
