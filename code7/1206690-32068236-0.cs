     switch ((a * 10) + b)
                {
                    case 12:
                        Console.WriteLine("Distance is " + Math.Sqrt(Math.Pow((obj2.x - obj1.x), 2) + Math.Pow((obj2.y - obj1.y), 2) + Math.Pow((obj2.z - obj1.z), 2)));
                        break;
                    case 13:
                        Console.WriteLine("Distance is " + Math.Sqrt(Math.Pow((obj3.x - obj1.x), 2) + Math.Pow((obj3.y - obj1.y), 2) + Math.Pow((obj3.z - obj1.z), 2)));
                        break;
                    case 23:
                        Console.WriteLine("Distance is " + Math.Sqrt(Math.Pow((obj3.x - obj2.x), 2) + Math.Pow((obj3.y - obj2.y), 2) + Math.Pow((obj3.z - obj2.z), 2)));
                        break;
    default:
                        Console.WriteLine("None of them");
                }
