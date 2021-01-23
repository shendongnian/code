    class ClassB : classA
    {
        public void printB()
        {
            Console.WriteLine("ClassB-PrintB Method");
        }
		
        public override void printA()
        {
            Console.WriteLine("Classb-PrintA Method");
			
			// Let's also call the ClassA version, just to show you how it works
			base.printA();
        }
	}
