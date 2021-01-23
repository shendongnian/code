    namespace PurushLogics
    {
        class Purush_ReverseInteger
        {
            static void Main()
            {
                //Reverse a Number  
                int intstr;
                string intreverse = "";
                int intLength = 0;
                int? intj = null;
                Console.WriteLine("Enter a Number"); // Entering "12345" has input will return "54321" as output
    
                intstr = int.Parse(Console.ReadLine());//Getting integer from Console  
    
                char[] inta = intstr.ToString().ToCharArray();
    
    
                intLength = inta.Length - 1;
                for (int c = intLength; c >= 0; c--)
                {
                    intreverse = intreverse + inta[c].ToString();
                    intj = int.Parse(intreverse);
                }
    
                Console.WriteLine("Reverse Number is \"{0}\"", intj);//Displaying the reverse integer  
                Console.ReadLine();
    
                //Reverse integer using Array.Reverse
                Array.Reverse(inta);
                foreach (char reverse in inta)
                {
                    Console.Write(reverse);
                }
                Console.ReadLine();
            }
        }
    }
