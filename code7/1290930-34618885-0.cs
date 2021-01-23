    //Class should have certain publicly accessible properties or methods to access from other classes.
        public class Input
        {
            public string MyInput {get; set;} //Publicly accessible property
            public void DisplayInput()  //Publicly accessible method
            {
                 Console.WriteLine(MyInput);
            } 
        }        
        
        
        public class InputService
        {
            Input test= new Input(); //Object initialization
        
            InputService()   //Constructor
            { 
                //Properties and methods can be accessed in methods. 
                test.MyInput = "Hello World!";  
                test.DisplayInput();
            }
            
        }
