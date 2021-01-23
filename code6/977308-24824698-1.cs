            float num, result;
            int opt;
            Console.Write("\t Enter your salary:");
            num = float.Parse(Console.ReadLine());
            Console.Write("\t Enter your option:");
            opt = Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    result = (num * 5) / 100;
                    Console.Write("\t You have to pay the tax of rupees: {0}", result);
                    break;
                case 2:
                    result = (num * 8) / 100;
                    Console.Write("\t You have to pay the tax of rupees: {0}", result);
                    break;
                case 3:
                    result = (num * 5) / 100;
                    Console.Write("\t You have to pay the tax of rupees: {0}", result);
                    break;
                default:
                    Console.WriteLine("Invalid Option...Please try again.");
                    break;
            }
            Console.ReadLine();
