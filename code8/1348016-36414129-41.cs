    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                throw new System.IO.FileNotFoundException();
            }
            catch(System.Exception ex)
            {
                System.Console.Write(ex.ToString());
                System.Console.ReadKey();
            }
        }
    }
