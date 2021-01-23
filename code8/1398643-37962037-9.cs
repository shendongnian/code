    using System;
    
    namespace Sodacrate
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Creates an object of class Sodacrate named Sodacrate
                var Sodacrate = new Sodacrate();
                Sodacrate.Run();
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    
        //Soda - contains the properties for the bottles that go in to the crate
        class Soda : IComparable<Soda>
        {
            string drinkName;
            string drinkType;
            int drinkPrice;
            int productCode;
    
            //Construct for the beverage
            public Soda(string _drinkName, string _drinkType, int _drinkPrice, int _productCode)
            {
                drinkName = _drinkName;
                drinkType = _drinkType;
                drinkPrice = _drinkPrice;
                productCode = _productCode;
            }
    
            //Property for the drink name e.g. Coca Cola, Ramlösa or Pripps lättöl
            public string Drink_name
            {
                get { return drinkName; }
                set { drinkName = value; }
            }
    
            //Property for the drink type e.g. Soda, fizzy water or beer
            public string Drink_type
            {
                get { return drinkType; }
                set { drinkType = value; }
            }
    
            //Property for the drink price in SEK
            public int Drink_price
            {
                get { return drinkPrice; }
                set { drinkPrice = value; }
            }
    
            //Property for the product code e.g. 1, 2 or ...
            public int Product_code
            {
                get { return productCode; }
                set { productCode = value; }
            }
    
            //Override for ToString to get text instead of info about the object
            public override string ToString()
            {
                return string.Format("{0} is a {1} costs {2} productcode {3} ", drinkName, drinkType, drinkPrice, productCode);
                //return string.Format("{0,0} Type {1,-16} Price {2,-10} Code {3, -5} ", drinkName, drinkType, drinkPrice, productCode);
            }
    
            //Compare to solve my issues with sorting
            public int CompareTo(Soda other)
            {
                if (other == null)
                {
                    return 1;
                }
    
                return drinkName.CompareTo(other.drinkName);
            }
    
        }
    
        static class Screen
        {
            // Screen - Generic methods for handling in- and output ======================================= >
    
            // Methods for screen handling in this object are:
            //
            //  cls()       Clear screen
            //  cup(row, col)       Positions the curser to a position on the console
            //  inKey()             Reads one pressed key (Returned value is : ConsoleKeyInfo)
            //  inStr()         Handles String
            //  inInt()     Handles Int
            //  inFloat()       Handles Float(Singel)
            //  meny()              Menu system , first invariable is Rubrik and 2 to 6 meny choises
            //  addSodaMenu()       The options for adding bottles
    
            // Clear Screen  ------------------------------------------
            static public void cls()
            {
                Console.Clear();
            }
    
            // Set Curser Position  ----------------------------------
            static public void cup(int column, int rad)
            {
                Console.SetCursorPosition(column, rad);
            }
    
            // Key Input --------------------------------------------
            static public ConsoleKeyInfo inKey()
            {
                ConsoleKeyInfo in_key; in_key = Console.ReadKey(); return in_key;
            }
    
            // String Input -----------------------------------------
            static public string inStr()
            {
                string in_string; in_string = Console.ReadLine(); return in_string;
            }
    
            // Int Input -------------------------------------------
            static public int inInt()
            {
                int int_in; try { int_in = Int32.Parse(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine("Input Error \b"); int_in = 0; }
                catch (OverflowException) { Console.WriteLine("Input Owerflow\b"); int_in = 0; }
                return int_in;
            }
    
            // Float Input -------------------------------------------
            static public float inFloat()
            {
                float float_in; try { float_in = Convert.ToSingle(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine("Input Error \b"); float_in = 0; }
                catch (OverflowException) { Console.WriteLine("Input Owerflow\b"); float_in = 0; }
                return float_in;
            }
    
            // Menu ------------------------------------------------
            static public int meny(string rubrik, string m_val1, string m_val2)
            {  // Meny med 2 val ---------------------
                int menSvar; menyRubrik(rubrik); menyRad(m_val1); menyRad(m_val2); menSvar = menyInm();
                return menSvar;
            }
    
            static public int meny(string rubrik, string m_val1, string m_val2, string m_val3)
            {  // Meny med 3 val ---------------------
                int menSvar; menyRubrik(rubrik); menyRad(m_val1); menyRad(m_val2); menyRad(m_val3); menSvar = menyInm();
                return menSvar;
            }
    
            static public int meny(string rubrik, string m_val1, string m_val2, string m_val3, string m_val4)
            {  // Meny med 4 val ---------------------
                int menSvar; menyRubrik(rubrik); menyRad(m_val1); menyRad(m_val2); menyRad(m_val3); menyRad(m_val4); menSvar = menyInm();
                return menSvar;
            }
    
            static public int meny(string rubrik, string m_val1, string m_val2, string m_val3, string m_val4, string m_val5)
            {  // Meny med 5 val ---------------------
                int menSvar; menyRubrik(rubrik); menyRad(m_val1); menyRad(m_val2); menyRad(m_val3); menyRad(m_val4); menyRad(m_val5); menSvar = menyInm();
                return menSvar;
            }
    
            static public int meny(string rubrik, string m_val1, string m_val2, string m_val3, string m_val4, string m_val5, string m_val6)
            {  // Meny med 6 val ---------------------
                int menSvar; menyRubrik(rubrik); menyRad(m_val1); menyRad(m_val2); menyRad(m_val3); menyRad(m_val4); menyRad(m_val5); ; menyRad(m_val6); menSvar = menyInm();
                return menSvar;
            }
    
            static void menyRubrik(string rubrik)
            {   // Meny rubrik --------
                cls(); Console.WriteLine("\n\t {0}\n----------------------------------------------------\n", rubrik);
            }
    
            static void menyRad(string menyVal)
            {   // Meny rad    --------
                Console.WriteLine("\t {0}", menyVal);
            }
    
            static int menyInm()
            { // Meny inmating ------
                int mVal; Console.Write("\n\t Menyval : "); mVal = inInt(); return mVal;
            }
    
            // Menu for adding bottles --------------------------------
            static public void addSodaMenu()
            {
                cls();
                Console.WriteLine("\tChoose a beverage please.");
                Console.WriteLine("\t1. Coca Cola");
                Console.WriteLine("\t2. Champis");
                Console.WriteLine("\t3. Grappo");
                Console.WriteLine("\t4. Pripps Blå lättöl");
                Console.WriteLine("\t5. Spendrups lättöl");
                Console.WriteLine("\t6. Ramlösa citron");
                Console.WriteLine("\t7. Vichy Nouveu");
                Console.WriteLine("\t9. Exit to main menu");
                Console.WriteLine("\t--------------------\n");
            }
    
            // Screen - Slut  <========================================
        } // screen <----
    
        class Sodacrate
        {
            // Sodacrate - Methods for handling arrays and lists of Soda-objects ======================================= >
    
            // Methods for Soda handling in this object are:
            //
            //  cls()       Clear screen
            //
            //
    
            private Soda[] bottles;             //Create they array where we store the up to 25 bottles
            private int numberOfBottles = 0;          //Keep track of the number of bottles in the crate
    
            //Not working
            public int find_Soda(string drinkname)
            {
                //Notes from teatcher   **=================start==================**
                //You should be able to search for name
                //You can use string-methods ToLower() or ToUpper() 
                //Notes from teatcher   **=================end====================**
    
                for (int i = 0; i < bottles.Length; i++)
                {
                    if (bottles[i].Drink_name == drinkname) //My feeble attempts
                        return i;
                }
                return -1;
            }
    
            //Exception error
            public void sort_Sodas()
            {
                int max = bottles.Length;
                //Outer loop for complete [bottles]
                for (int i = 1; i < max; i++)
                {
                    //Inner loop for row by row
                    int nrLeft = max - i;
                    for (int j = 0; j < (max - i); j++)
                    {
                        var bottle1 = bottles[j];
                        var bottle2 = bottles[j + 1];
    
                        if((bottle1 == null) || (bottle2 == null))
                        {
                            continue;
                        }
    
                        if (bottle1.Product_code > bottle2.Product_code)
                        {
                            var temp = bottles[j];
                            bottles[j] = bottles[j + 1];
                            bottles[j + 1] = temp;
                        }
                    }
                }
            }
    
            //Exception error
            public void sort_Sodas_name()
            {
                //var tempb = bottles.OrderBy(x => x.Drink_name).ToArray();
                //bottles = tempb;
    
                int max = bottles.Length;
                //Outer loop for complete [bottles]
                for (int i = 1; i < max; i++)
                {
                    //Inner loop for row by row
                    int nrLeft = max - i;
                    for (int j = 0; j < (max - i); j++)
                    {
                        var bottle1 = bottles[j];
                        var bottle2 = bottles[j + 1];
    
                        if ((bottle1 == null) || (bottle2 == null))
                        {
                            continue;
                        }
                        //Error CS0122  'Soda.drinkName' is inaccessible due to its protection level
                        if (bottle1.Drink_name.CompareTo(bottle2.Drink_name) == 1)
                        {
                            var temp = bottles[j];
                            bottles[j] = bottles[j + 1];
                            bottles[j + 1] = temp;
                        }
                    }
                }
            }
    
            //Search for Product code ony returns the first hit
            public int LinearSearch(int key)
            {
    
                for (int i = 0; i < bottles.Length; i++)
                {
                    if (bottles[i].Product_code == key)
                        return i;
                }
                return -1;
            }
    
            //Contains the menu to choose from the crates methods
            public void Run()
            {
                //Quick and dirty add of data. I got this working fine
                bottles[0] = new Soda("Coca Cola", "Soda", 5, 1);
                bottles[1] = new Soda("Champis", "Soda", 6, 1);
                bottles[2] = new Soda("Grappo", "Soda", 4, 1);
                bottles[3] = new Soda("Pripps Blå", "beer", 6, 2);
                bottles[4] = new Soda("Spendrups", "beer", 6, 2);
                bottles[5] = new Soda("Ramlösa", "water", 4, 3);
                bottles[6] = new Soda("Loka", "water", 4, 3);
                bottles[7] = new Soda("Coca Cola", "Soda", 5, 1);
    
                print_crate();  //Happy with this one I need to shape up the ToString override
                Console.WriteLine("\n\tYou have {0} bottles in your crate:\n\n", bottleCount());
    
                Console.WriteLine("\nTotal value of the crate is {0}", calc_total());//Happy as a clam
    
                int price = 0; //Causes exception error I lack understanding
    
                foreach (var bottle in bottles)
                {
                    if (bottle == null)
                    {
                        continue;
                    }
                    price = price + bottle.Drink_price;
                }
    
                Console.WriteLine("\tThe total value of the crate is {0} SEK.", price);
    
                Screen.inKey();
                Screen.cls();
    
                int test = 0;
                test = bottles[3].Product_code;//So bottles[i].xyz  do some things and bottles.xyz others
                Console.WriteLine("Product code {0} is in slot {1}", test, 3);
                Screen.inKey();
    
                //This only returns the first product with the asked productcode. How to get all? Also what if I searched for name like Coca Cola instead?
                Console.WriteLine("Type 1, 2 or 3");
                int prodcode = Screen.inInt();
                Console.WriteLine(LinearSearch(prodcode));
                Console.WriteLine("Product code {0} is in slot {1}", prodcode, (LinearSearch(prodcode)));
                Console.WriteLine(bottles[(LinearSearch(prodcode))]);
    
                Console.WriteLine("\nbefore sort\n");
                Screen.inKey();
                print_crate();
                Console.WriteLine("\nafter sort\n");
                sort_Sodas();         //Causes Exception error I want it to sort on either product code or product name
                print_crate();        //Check if the sort has put two Coca Cola on top.
                Console.WriteLine("\nafter sort name\n");
                sort_Sodas_name();
                print_crate();        //Check if the sort has put two Coca Cola on top.
            }
    
            //Print the content of the crate to the console
            public void print_crate()
            {
                foreach (var beverage in bottles)
                {
                    if (beverage != null)
                        Console.WriteLine(beverage);
                }
                Console.WriteLine("\n\tYou have {0} bottles in your crate:", bottleCount());
            }
    
            //Construct, sets the Sodacrate to hold 25 bottles
            public Sodacrate()
            {
                bottles = new Soda[25];
            }
    
            // Count the ammounts of bottles in crate
            public int bottleCount()
            {
                int cnt = numberOfBottles;
                // Loop though array to get not empty element
                foreach (var beverages in bottles)
                {
                    if (beverages != null)
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
    
            //Calculates the total value of the bottles in the crate
            public int calc_total()
            {
                int temp = 0;
                for (int i = 0; i < bottleCount(); i++)
                {
                    temp = temp + (bottles[i].Drink_price);
                }
                return temp;
            }
            //Adds bottles in the crate.
            public void add_Soda()
            {
                //I start of with adding 7 bottles to avoid having to add so many bottles testing functions. Remove block before release 
                bottles[0] = new Soda("Coca Cola", "Soda", 5, 1);
                bottles[1] = new Soda("Champis", "Soda", 6, 1);
                bottles[2] = new Soda("Grappo", "Soda", 4, 1);
                bottles[3] = new Soda("Pripps Blå", "lättöl", 6, 2);
                bottles[4] = new Soda("Spendrups", "lättöl", 6, 2);
                bottles[5] = new Soda("Ramlösa citron", "mineralvatten", 4, 3);
                bottles[6] = new Soda("Vichy Nouveu", "mineralvatten", 4, 3);
                //<====================================== End block
    
                int beverageIn = 0;//Creates the menu choice-variable
                while (beverageIn != 9)//Exit this menu by typing 9 - This value should be different if we add more bottle types to add.
                {
                    Screen.addSodaMenu();//Calls the menu in the Screen-class
                    Console.WriteLine("You have {0} bottles in the crate.\n\nChoose :", bottleCount());
                    Screen.cup(8, 13);
                    int i = bottleCount();//Keeps track of how many bottles we have in the crate. If the crate is full we get expelled out of this method
                    if (i == 25)
                    { beverageIn = 9; }
                    else beverageIn = Screen.inInt();//end
    
                    switch (beverageIn) //Loop for adding bottles to the crate exit by pressing 9
                    {
                        case 1:
                            i = bottleCount();
                            bottles[i] = new Soda("Coca Cola", "Soda", 5, 1);
                            i++;
                            break;
    
                        case 2:
                            i = bottleCount();
                            bottles[i] = new Soda("Champis", "Soda", 6, 1);
                            i++;
                            break;
    
                        case 3:
                            i = bottleCount();
                            bottles[i] = new Soda("Grappo", "Soda", 4, 1);
                            i++;
                            break;
    
                        case 4:
                            i = bottleCount();
                            bottles[i] = new Soda("Pripps Blå lättöl", "lättöl", 6, 2);
                            i++;
                            break;
    
                        case 5:
                            i = bottleCount();
                            bottles[i] = new Soda("Spendrups lättöl", "lättöl", 6, 2);
                            i++;
                            break;
    
                        case 6:
                            i = bottleCount();
                            bottles[i] = new Soda("Ramlösa citron", "mineralvatten", 4, 3);
                            i++;
                            break;
    
                        case 7:
                            i = bottleCount();
                            bottles[i] = new Soda("Vichy Nouveu", "mineralvatten", 4, 3);
                            i++;
                            break;
    
                        case 9:
                            i = bottleCount();
                            if (i == 25)
                            {
                                Console.WriteLine("\tThe crate is full\n\tGoing back to main menu. Press a key: ");
                            }
                            Console.WriteLine("Going back to main menu. Press a key: ");
                            break;
    
                        default://Default will never kick in as I have error handling in Screen.inInt()
                            Console.WriteLine("Error, pick a number between 1 and 7 or 9 to end.");
                            break;
                    }
                }
            }
            // Sodacrate - End  <========================================
        }
    }
