    using System;
    using System.Collections.Generic;
    
    namespace NumberListExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> list = new List<int>();
                string userInput = string.Empty;
                int number;
    
                Console.WriteLine("Type numbers and hit enter to add to list.\nDo not repeat numbers.\nTo stop, type 'exit'. To print the list, type 'print'.");
                do
                {
                    Console.Write("Enter a whole number: ");
                    try //Throw exceptions to be handled later.
                    {
                        userInput = Console.ReadLine(); //Read in user input
    
                        if (userInput.ToUpper() == "PRINT") //if the user desires to print...
                        {
                            PrintList(list);
                        }
                        else //If the user hasn't requested a print...
                        {
                            if (int.TryParse(userInput, out number))
                            {
                                //if the list doesn't contain this value
                                if (!list.Contains(number))
                                {
                                    //add to the list
                                    list.Add(number);
                                }
                                else //the list contains the value
                                {
                                    //Throw a new exception specifying the problem
                                    throw new Exception(string.Format("This list already contains {0}!", number));
                                }
                            }
                            else
                            {
                                throw new Exception("This is not a whole number.");
                            }
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine("Cannot accept null values!");
                    }
                    catch (Exception ex) //Print the exception message.
                    {
                        //Print the message of the exception thrown:
                        Console.WriteLine(ex.Message);
                    }
    
                } while (userInput.ToUpper() != "EXIT");//Accept all casing by first converting input to uppercase.
    
    
            }
    
            private static void PrintList(IEnumerable<int> list)
            {
                Console.WriteLine("List of numbers:");
                foreach (int number in list)
                {
                    Console.Write("{0}, ", number);
                }
                //Skip a line:
                Console.WriteLine();
            }
        }
    }
