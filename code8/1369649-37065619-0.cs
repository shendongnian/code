    class Program
    {
        static int tableWidth = 77;
        static string columnSeparator = string.Empty;
        static void Main(string[] args)
        {
            string ut = "1Y, 4D, 01:23:45";
            string met = "T+4D, 01:11:32";
            string vesselName = "Saturn K";
            string vesselModules = "Command/Service Module \nMunar Excursion Module";
            string kerbals = "Valentina Kerman, Pilot; \nJebediah Kerman, Pilot; \nBill Kerman, Engineer; \nBob Kerman, Scientist";
            string[] headerNames = { "UT:", "MET:", "Vessel:", "Modules:", "Crew:" };
            string[] headerData = new string[5] { ut, met, vesselName, vesselModules, kerbals };
            for (int index = 0; index < headerNames.Length; index++)
            {
                var multiCol = headerData[index].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                int counter = 0;
                foreach (var col in multiCol)
                {
                    PrintRow(new string[] { counter == 0 ? headerNames[index] : string.Empty, col });
                    counter++;
                }
            }
            Console.Read();
        }
        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = columnSeparator;
            foreach (string column in columns)
            {
                row += AlignLeft(column, width) + columnSeparator;
            }
            Console.WriteLine(row);
        }
        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        static string AlignLeft(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width);
            }
        }
    }
