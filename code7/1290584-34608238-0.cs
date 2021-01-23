    class Program
    {
        static void Main(string[] args)
        {
            string nameValueList = "|||zeeshan|1||ali|2||ahsan|3|||";
            while (nameValueList != "|||")
            {
                nameValueList = nameValueList.TrimStart('|');
                string nameValue = GetNameValue(ref nameValueList);
                Console.WriteLine(nameValue);
            }
            Console.ReadLine();
        }
        private static string GetNameValue(ref string nameValues)
        {
            string retVal = string.Empty;
            while(nameValues[0] != '|') // for name
            {
                retVal += nameValues[0];
                nameValues = nameValues.Remove(0, 1);
            }
            retVal += nameValues[0];
            nameValues = nameValues.Remove(0, 1);
            while (nameValues[0] != '|') // for value
            {
                retVal += nameValues[0];
                nameValues = nameValues.Remove(0, 1);
            }
            return retVal;
        }
    }
