            int x = 0;
            do
            {
                string z = "TEST";
                Console.WriteLine(x.ToString());
                ++x;
            }
            while (x < 7);
            Console.WriteLine(z); // invalid!
