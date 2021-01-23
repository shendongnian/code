    public class Class1
    {
        [Flags]
        private enum DateTypeRequired : byte
        {
            Prefix = 1,
            Suffix = 2
        }
        public static void Main(string[] args)
        {
            string myFileName = "test.xls";
            var settings = DateTypeRequired.Prefix | DateTypeRequired.Suffix;
            AppendDateToFile(ref myFileName, settings);
            Console.Write(myFileName);
            Console.ReadKey();
        }
        private static void AppendDateToFile(ref string fileName, DateTypeRequired datesNeeded)
        {
            if ((datesNeeded & DateTypeRequired.Prefix) == DateTypeRequired.Prefix)
            {
                fileName = string.Concat(DateTime.Now.ToString("ddmmyyyy"), fileName);
            }
            if ((datesNeeded & DateTypeRequired.Suffix) == DateTypeRequired.Suffix)
            {
                string[] fileParts = fileName.Split(new char[]{'.'});
                fileName = string.Concat(fileParts[0],
                                string.Concat(DateTime.Now.ToString("ddmmyyyy.")), fileParts[1]);
            }
        }
    }
