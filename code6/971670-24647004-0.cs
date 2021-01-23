    class MyProgram: Access
    {
        //Make a non-static method and this field would be available
        public void ma()
        {
            //you will find the field here
            this.name ="some name"
        }
        static void Main(string[] args)
        {
          //Error here
          Access ac1=new Access();
          Console.WriteLine("Enter your name: ");
          
          //field would not be available here because you are making object
          ac1.name = Console.ReadLine();
          ac1.print();
         //Do it like
         //it would work because of inheritance
         var localObject = new MyProgram()
         localObject.name = Console.ReadLine();
         localObject.print();
        }
    }
