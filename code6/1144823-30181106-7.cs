       internal class SO30180672
       {
          internal static void RunTest()
          {
             Console.WriteLine(FormatNumber(1));
             Console.WriteLine(FormatNumber(10));
             Console.WriteLine(FormatNumber(100));
             Console.WriteLine(FormatNumber(1000));
             Console.WriteLine(FormatNumber(10000));
             Console.WriteLine(FormatNumber(100000));
             Console.WriteLine(FormatNumber(125000));
             Console.WriteLine(FormatNumber(125900));
             Console.WriteLine(FormatNumber(1000000));
             Console.WriteLine(FormatNumber(1250000));
             Console.WriteLine(FormatNumber(1258000));
             Console.WriteLine(FormatNumber(10000000));
             Console.WriteLine(FormatNumber(10500000));
             Console.WriteLine(FormatNumber(100000000));
             Console.WriteLine(FormatNumber(100100000));
          }
    
          private static string FormatNumber(long num)
          {
             long i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(num) - 2));
             num = num / i * i;
    
             if (num >= 1000000000)
                return (num / 1000000000D).ToString("0.##") + "B";
             if (num >= 1000000)
                return (num / 1000000D).ToString("0.##") + "M";
             if (num >= 1000)
                return (num / 1000D).ToString("0.##") + "K";
    
             return num.ToString("#,0");
          }
       }
