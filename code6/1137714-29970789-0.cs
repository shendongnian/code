    public class Program
    {
        public static void Main()
        {
         	Console.WriteLine("Enter a phone number.");
        	string telNo = Console.ReadLine();						
        	Console.WriteLine("{0}correctly entered", IsPhoneNumber(telNo) ? "" : "in");	
        	Console.ReadLine();	
        }
        
        public static bool IsPhoneNumber(string number)
        {
        	return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
    }
