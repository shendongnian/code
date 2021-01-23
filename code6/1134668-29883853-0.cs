    public static void Main()
        {
            int month = 0;
            bool exit = false;
            while (!exit)
            {
                //Range 1-12 refers to Month
                Console.WriteLine("Please enter Month in numerical increments (1-12)");
                month = int.Parse(Console.ReadLine());
                switch (month)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.WriteLine("This is the First Month...January");
                        break;
                    case 2:
                        Console.WriteLine("This is the Second Month...Februrary");
                        break;
                    case 3:
                        Console.WriteLine("This is the Third Month...March");
                        break;
                    case 4:
                        Console.WriteLine("This is the Fourth Month...April");
                        break;
                    case 5:
                        Console.WriteLine("This is the Fifth Month...May");
                        break;
                    case 6:
                        Console.WriteLine("This is the Sixth Month...June");
                        break;
                    case 7:
                        Console.WriteLine("This is the Seventh Month...July");
                        break;
                    case 8:
                        Console.WriteLine("This is the Eighth Month...August");
                        break;
                    case 9:
                        Console.WriteLine("This is the Ninth Month...September");
                        break;
                    case 10:
                        Console.WriteLine("This is the Tenth Month...October");
                        break;
                    case 11:
                        Console.WriteLine("This is the Eleventh Month...November");
                        break;
                    case 12:
                        Console.WriteLine("This is the Twelfth Month...December");
                        break;
                    default:
                        Console.WriteLine("You have inputed an invalid Character");
                        break;
                }
            }
            //Attempt to looP code
        }
