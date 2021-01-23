        List<Shape> shapes = new List<Shape>();
        do
        {
            Console.ReadKey();
            Console.WriteLine("Choose a form:");
            Console.WriteLine("1:Triangle");
            Console.WriteLine("2:Square");
            Console.WriteLine("3:Circle");
            Console.WriteLine("4:Exit");
            Int32.TryParse(Console.ReadLine(), out i);
            if (i == 1)
            {
                Console.WriteLine("l1:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("l2:");
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("l3:");
                int q = Convert.ToInt32(Console.ReadLine());
                Triangle t = new Triangle(n, m, q);
                shapes.Add(t);
                t.GetPrint();
                Console.ReadKey();
            }
            // do the same for square and circle
            // shapes.Add(variable);
