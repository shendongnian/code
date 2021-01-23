    using System;
    using System.Text;
	
    namespace helloworld
    {
    public class Program
    {
        public static void Main(string[] args)
        {
             string text = "ä";
             byte[] bytes = Encoding.GetEncoding(1252).GetBytes(text);
             var convertedBytes = Encoding.Convert(Encoding.GetEncoding(1252),Encoding.GetEncoding(437), bytes);
			
			 Console.WriteLine(Encoding.GetEncoding(437).GetString(convertedBytes));
        }
    }
}
