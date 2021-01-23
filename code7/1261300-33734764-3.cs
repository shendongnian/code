    public class Formula
    {
        // public double F; remove because F is used as parameter
        public double C;
        public void calculate(double F)
        {
            C = (5.0 / 9.0) * (F - 32.0);    
        }
    
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter the Fahrenheit you wish to convert");
            var   F = double.Parse(Console.ReadLine()); // Creating new variable
            Formula form = new Formula();
            form.calculate(F); // Pass parameter to our function
            Console.WriteLine(F + "Fahrenheit correspond to " + form.C /* retrive the results of calculation */ + "Degrees celcius"); 
        }
    }
