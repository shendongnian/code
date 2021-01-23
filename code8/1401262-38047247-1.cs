    class Program
       {
        static void MethodA()
        {
            Console.WriteLine("Static method");
        }
        void MethodB()
        {
            Console.WriteLine("Instance method");
        }
        static char MethodC()
        {
            Console.WriteLine("Static method");
            return 'C';
        }
        char MethodD()
        {
            Console.WriteLine("Instance method");
            return 'D';
        }
        static void Main()
        {
            //
            // Call the two static methods on the Program type.
            //
            Program.MethodA();
            Console.WriteLine(Program.MethodC());
            //
            // Create a new Program instance and call the two instance methods.
            //
            Program programInstance = new Program();
            programInstance.MethodB();
            Console.WriteLine(programInstance.MethodD());
            Console.ReadLine();
        }
    }
