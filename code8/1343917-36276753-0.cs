            var result = (double) new DataTable().Compute("20 / 0", null);
            if(double.IsInfinity(result))
            {
                Console.WriteLine("Oh noes!"); // Debugger lands here
            }
            Console.WriteLine(result);
        }
