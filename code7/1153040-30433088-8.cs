            Product product = new Product();
            product._id = "fisrt value";
            List<Product> productList1 = new List<Product>();
            List<Product> productList2 = new List<Product>();
            productList1.Add(product);
            product = new Product(); // initialize a new instance
            product._id = "second value";
            productList2.Add(product);
            product = new Product();// initialize another new instance
            product._id = "new value";
            Console.WriteLine("List 1:");
            foreach (var p in productList1)
            {
                Console.WriteLine(p._id + " ");
            }
            Console.WriteLine("List 2:");
            foreach (var p in productList2)
            {
                Console.WriteLine(p._id + " ");
            }
            Console.WriteLine("Last value: " + product._id);
            Console.ReadKey();
          //RESULT: List1: first value
          //        List2: second value
          //        Last value: new value
