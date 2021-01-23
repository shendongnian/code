    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var customer = new Customer();
                customer.FirstName = GetStringValueFromConsole("Customer First Name");
                customer.LastName = GetStringValueFromConsole("Customer Last Name");
                Console.WriteLine("New Customers name: " + customer.FullName);
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
    
            private static string GetStringValueFromConsole(string valueToAskFor)
            {
                var needToGetInputFromUser = false;
                var stringValue = string.Empty;
                do
                {
                    Console.WriteLine("Please enter " + valueToAskFor);
                    stringValue = Console.ReadLine();
                    if (stringValue.Length < 5 || stringValue.Length > 20)
                    {
                        Console.WriteLine("Invalid \"" + valueToAskFor + "\", must be between 5 and 20 characters");
                        Console.WriteLine("Please try again.");
                        Console.WriteLine(" ");
                        needToGetInputFromUser = true;
                    }
                    else
                    {
                        needToGetInputFromUser = false;
                    }
                } while (needToGetInputFromUser);
                return stringValue;
            }
        }
    }
