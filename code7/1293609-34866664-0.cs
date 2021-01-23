    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace Language
    {
       public class Test
       {
          //Imports dll to set console display
           [DllImport("kernel32.dll"]
           public static extern bool SetConsoleCP(int codepage);
           [DllImport("kernel32.dll"]
           public static extern bool SetConsoleOutputCP(int codepage);
       public static void Main()
        {
           string s = "ÑÁÅ";
           byte[] bytes = new byte[s.Length * sizeof(char)];
           System.Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0,  bytes.Length);
           Console.WriteLine(BitConverter.ToString(bytes);
         //produce possible combinations
           foreach (Encoding encw in Russian.GetCps())
           {
              bool cp = SetConsoleOutputCP(encw.CodePage);
              bool cp2 = SetConsoleCP(encw.CodePage);
              foreach (Encoding enc in Russian.GetCps())
              {
                  char[] ca = enc.GetChars(bytes);
                  Console.WriteLine(ca);
               }
             }
           }
         }
    public class Russian
    {
        public static Encoding[] GetCps()
        {
         // get applicable Cyrillic pages
         Encoding[] = russian = new Encoding[8];
         russian[0] = Encoding.GetEncoding(855);  
         russian[1] = Encoding.GetEncoding(866);     
         russian[2] = Encoding.GetEncoding(1251); 
         russian[3] = Encoding.GetEncoding(10007); 
         russian[4] = Encoding.GetEncoding(20866); 
         russian[5] = Encoding.GetEncoding(21866); 
         russian[6] = Encoding.GetEncoding(20880); 
         russian[7] = Encoding.GetEncoding(28595);
         return russian;
        } 
     }
    }   
