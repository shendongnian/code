    public class Program
    {
        static void Main(string[] args)
        {
            int counter;
            double score;
            while (true)
            {
                counter = 1;
                score = 0.0;
                Console.WriteLine("Enter Your Name or type 'exit' to quit): ");
                // Naming for exiting 
                string name = Console.ReadLine();
                if (name == "exit")
                {
                    return;
                }
                else
                {
                    int numberOfUnits = 20;
                    Console.WriteLine("Number of Units:  ");
                    numberOfUnits = int.Parse(Console.ReadLine());
                    while (counter <= numberOfUnits)
                    {
                        Console.WriteLine("Final Grade Score {0}", counter);
                        string s = Console.ReadLine().ToUpper();
                        double d;
                        if (double.TryParse(s, out d)) //parsing as a number was successfull, and the result is in d.
                            score += d;
                        else //parsing failed.
                        {
                            switch (s)
                            {
                                case "D":
                                    score += 20;
                                    break;
                                case "M":
                                    score += 50;
                                    break;
                                case "P":
                                    score += 70;
                                    break;
                                default:
                                    counter--; //parsing of a letter failed. reducing counter that will be later incremented, to offset the effect.
                                    Console.WriteLine("Could not parse your grade. Enter a number or a letter");
                                    break;
                            }
                        }
                        counter++;
                    }
                    // Add up and print letter grade. 
                    score = (score / (counter - 1));
                    if (score < 120) Console.WriteLine("Letter Grade: PPP");
                    else if (score < 160) Console.WriteLine("Letter Grade: MPP");
                    else if (score < 200) Console.WriteLine("Letter Grade: MMP");
                    else if (score < 240) Console.WriteLine("Letter Grade: MMM");
                    else if (score < 280) Console.WriteLine("Letter Grade: DMM");
                    else if (score < 320) Console.WriteLine("Letter Grade: DDM");
                    else if (score < 360) Console.WriteLine("Letter Grade: DDD");
                    // After DDD it goes up by 20's ..... D* = 20 not 40...
                    else if (score < 380) Console.WriteLine("Letter Grade: D*DD");
                    else if (score < 400) Console.WriteLine("Letter Grade: D*D*D");
                    else if (score < 420) Console.WriteLine("Letter Grade: D*D*D*");
                    Console.WriteLine("Grade: {0}", (score).ToString("P"));
                }
            }
        }
    }
