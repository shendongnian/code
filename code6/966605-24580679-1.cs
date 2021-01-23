    public class Program
    {
        static void Main(string[] args)
        {
            TelephoneMP3 t = new TelephoneMP3();
            Console.WriteLine((t is TelephoneMP3)? true:false);
            Console.WriteLine((t is ITelephone) ? true : false);
            Console.WriteLine((t is IMP3) ? true : false);
            Console.WriteLine((t is Telephone) ? true : false);
            Console.WriteLine((t is MP3) ? true : false);
            Console.ReadLine();
        }
    }
