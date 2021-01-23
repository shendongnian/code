    public class SomeClass {
        // this is your code behind file
        public MyObject my_object {get;set;} 
        // this is where you go when you hit the button
        OnButtonClick(sender, event) {
            //my_object is accessible here. Assuming it has a DoSomething method, you can:
            my_object.DoSomething();
        }
    }
            
