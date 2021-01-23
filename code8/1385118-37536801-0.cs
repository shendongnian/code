                case "/":
                    while (num2 == 0)
                    {
                        Console.WriteLine("You cannot devide by zero, please select a different number.");
                        num2 = Convert.ToInt32(Console.ReadLine());
                    }
                    
                    answer = num1 / num2;
                    Console.WriteLine(num1 + " / " + num2 + " = " + answer);
                    Console.ReadKey();
                    break;
