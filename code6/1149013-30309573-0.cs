        static void Main(string[] args)
        {
            string k = "!00037,00055@";
            var array = k.ToString().Split(',');
            Console.WriteLine("Dirty Itens");
            for (var x = 0; x <= array.Length - 1; x++)
            {
                var linha = "Item " + x.ToString() + " = " + array[x];
                Console.WriteLine(linha);
            }
            Console.WriteLine("Cleaned Itens");
            for (var x = 0; x <= array.Length - 1; x++)
            {
                var linha = "Item " + x.ToString() + " = " + CleanString(array[x]);
                Console.WriteLine(linha);
            }
            Console.ReadLine();
        }
        public static string CleanString(string inputString)
        {
            string resultString = "";
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(inputString, "");
            return resultString;            
        }
