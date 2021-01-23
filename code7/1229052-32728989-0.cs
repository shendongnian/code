    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                //declare a char variable to store the degree symbol
                char chrDegree = (char)176;
                Boolean boolContinue = true;
                string strContinue;
                //declare two doubles to store F and C temperature
                double dblF, dblC;
    
    
                while (boolContinue == true)
                {
    
                    //display program info
                    Console.WriteLine("Temperature Conversions with Advice (v.1) Sept 17, 2015");
                    Console.WriteLine("-------------------------------------------------------\n\n");
                    //prompt user to enter the temperature in F
                    Console.Write("Enter today's temperature in {0} F (eg 60): ", chrDegree);
    
                    //read in the user input
                    string strF = Console.ReadLine();
    
    
                    //convert input from string to double
                    dblF = Convert.ToDouble(strF);
    
                    //calculate celsius using fahrenheit
                    dblC = (dblF - 32) * 5 / 9;
    
                    Console.WriteLine("\n\nToday's Temperature: {0:F2}{1} F = {2:F2}{1} C \n\n",
                        dblF, chrDegree, dblC);
    
                    //if the user enters < 40
                    if (dblF < 40)
                    {
                        Console.WriteLine("\n\nIt is very cold. Put on a heavy coat.");
                    }
    
                    else if (dblF > 40 && dblF < 60)
                    {
                        Console.WriteLine("\n\nIt is cold. Put on a coat.");
                    }
    
                    else if (dblF >= 60 && dblF < 70)
                    {
                        Console.WriteLine("\n\nThe temperature is cool. Put on a light jacket.");
                    }
    
                    else if (dblF >= 70 && dblF < 80)
                    {
                        Console.WriteLine("\n\nThe temperature is pleasant. Wear anything you like.");
                    }
    
                    else if (dblF >= 80 && dblF < 90)
                    {
                        Console.WriteLine("\n\nThe temperature is warm. Wear short sleeves.");
                    }
    
                    else if (dblF >= 90)
                    {
                        Console.WriteLine("\n\nIt is hot. Wear shorts today.");
                    }
    
                    Console.WriteLine("Thank you for using the Temperature Conversion Application.\n\n");
                    //ask if the user wants to continue
                    Console.Write("Do you want to continue Y/N ? ");
                    //reads in the user input
                    strContinue = Console.ReadLine();
                    Console.WriteLine("\n\n");
    
                    //if the user enters N or n
                    if (strContinue == "N" || strContinue == "n")
                    {
                        //set the bool variable to false
                        boolContinue = false;
                    }
                    //otherwise
                    else
                    {
                        //set the boolean variable to true
                        boolContinue = true;
                    }
    
                    Console.ReadKey();
                }
    
            }
        }
    }
