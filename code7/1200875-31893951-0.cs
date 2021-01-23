    class Program
    {
        static void Main(string[] args)
        {
            var test = new Example();
            Console.ReadLine();
        }
    }
    class Example
    {
        //This is the event definition
        delegate void ActionDelegate(string input1, string input2);
        // Two event handler which implements the signature of the event
        void ActionMethod(string a, string b)
        {
            Console.WriteLine(a + " " + b);
        }
        void ActionMethod2(string c, string d)
        {
            Console.WriteLine("Wow one more function called with parameter {0} and {1}", c, d);
        }
        delegate Tuple<string, string> LamdaDelegate(string input1, string input2);
        public Example()
        {
			//Did not declare any delegate member variable explicitly.
            //Clean and easy to understand
            Action<string, string> action = ActionMethod;
			// Had to define the delegate with method signature explicitly before using it
            ActionDelegate actionDelegate = ActionMethod; 
            actionDelegate += ActionMethod2; // Attaching more event handlers to the event
			
			//The below lambda expression implicitly means that it will take two inputs each of type string
			// and does not return anything. 
            //The type information is implicitly derived from the method signature of the delegate
            actionDelegate += (a, b) => Console.WriteLine("Called using lambda expression");
            //Below is a Lambda expression in which s and e each is of type string 
            //Since the return type of the delegate is Tuple<string,string> the same is returned by the expression
            //Lambda expression is using a delegate without defining a delegate explicitly. 
            LamdaDelegate myTuple = (s, e) => { return Tuple.Create(s, e); };
            //The above Lambda can be rewritten as
            myTuple += delegate (string a, string b) { return Tuple.Create(a, b); };
            //Invoking the event handlers. The event handlers are executed automatically when ever the event occurs 
            action("Hi", "called from action");
            actionDelegate("Hi", "called using explicitly defined delegate");
        }
    }
