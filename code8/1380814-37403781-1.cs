        public static int item { get; set; }
        //just declare your arrays here
        public string[] product;
        public string[] code;
        public string[] price;
        public string[] unit;
        public void addItem()
        {
            Console.WriteLine("\nAmount of items to add");
            item = Convert.ToInt32(Console.ReadLine());
            //instantiate your arrays here since item will have a value you have set it into.
            product = new string[item];
            code = new string[item];
            price = new string[item];
            unit = new string[item];
            Console.WriteLine("Insert the items.");
