    public class CapitalOrNot
    {
        public static void Main()
        {
            string sentence = "Asdafasda";
            
            if(sentence.Length > 0 && sentence != null)
            {
                string UpOrLow = UpperOrLower(sentence);
                Console.WriteLine("First char is " + UpOrLow);
            }
            else
            {
               Console.WriteLine("You did not input a sentence");
            }
        }
    
        public static string UpperOrLower(string mj)
        {
            if (char.IsUpper(mj[0]))
            {
                mj = "upper";
            }
            else mj = "lower";
    
            return mj;
        }
    }
