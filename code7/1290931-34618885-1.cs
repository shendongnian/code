    //Class should have certain publicly accessible properties or methods to access from other classes.
        public class Input
        {
            private int x = 5;
            public string MyInput {get; set;} //Publicly accessible property
            public void DisplayInput()  //Publicly accessible method
            {
                 Console.WriteLine(MyInput);
                 Console.WriteLine(x);
            } 
        }        
        
        
        public class InputService
        {
            Input test= new Input(); //Object initialization
        
            InputService()   //Constructor
            { 
                //Properties and methods can be accessed in methods. 
                test.MyInput = "Hello World!";  
                //test.x   you can't access x because it is private.
                test.DisplayInput();
 
            }
            
        }
