    public class pairInName
    {
        string[] splitChampName;
        public static void myOperations()
        {
            foreach (string champName in namesList.splitListOfNames)
            {
                splitChampName = champName.Split(',');
            }
        }
        
        public string[] getSplitResult
        {
            get { return splitChampName; }
        }
    }
