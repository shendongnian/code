    using System;
    using System.Text;
	
    namespace helloworldwcond
    {
    public class Program
    {
        public static void Main(string[] args)
        {
             string text = "ä";
             byte[] bytes = Encoding.GetEncoding(1252).GetBytes(text);
             var convertedBytes = Encoding.Convert(Encoding.GetEncoding(1252),Encoding.ASCII, bytes);
			
			 Console.WriteLine(Encoding.ASCII.GetString(convertedBytes));
        }
    }
}
