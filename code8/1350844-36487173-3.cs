            Console.Write("Enter your Length: ");
            int length = new int();
            length = int.Parse(Console.ReadLine());
            Console.Write("Enter your Width: ");
            int width = new int();
            width = int.Parse(Console.ReadLine());
            Console.Write("Enter your Height: ");
            int height = new int();
            height = int.Parse(Console.ReadLine());
            int totalDims = new int();
            totalDims = length * width * height;
            //isnt cubic feet just length * width * height?
            //decimal cubicFeet = new decimal();
            //cubicFeet = totalDims;
            Console.WriteLine("Your total cubic feet is " + totalDims);
            Console.ReadLine();
