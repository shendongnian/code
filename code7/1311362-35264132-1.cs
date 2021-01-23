	class TestDelegate
    {
        public delegate int NumberChanger(int n);
        static void Main(string[] args)
        {
            //create instance of class
            Arithmetic art = new Arithmetic();
            //create delegate instances
            NumberChanger nc1 = new NumberChanger(art.AddNum);  //call with reference
            NumberChanger nc2 = new NumberChanger(art.MultNum); //call with reference
            //calling the methods using the delegate objects
            
            //add
            Console.WriteLine("Value of Num: {0}", nc1(25)); //use it directly because your delegate returns a value
            
            //product
            Console.WriteLine("Value of Num: {0}", nc2(5)); //use it directly because your delegate returns a value
            Console.ReadKey();
        }
    }
	
	
