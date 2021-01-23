                if (Enum.TryParse<Elements>(userInput1, true, out element))
                {
                    switch (element)
                    {
                        case Elements.Na:
                            myTwoMassCalculation.Element1 = 22.990;
                            break;
                        case Elements.Cl:
                            myTwoMassCalculation.Element1 = 35.453;
                            break;
                        default:
                            break;
                    }   
                }
                Console.WriteLine("How many?");
                string userAmount1 = Console.ReadLine();
                int myAmount1 = int.Parse(userAmount1);
                myTwoMassCalculation.Amount1 = myAmount1;
