        private void functionX()
        {
            string name = "test_test1_test2_test3";
            string[] splitValues = name.Split('_');
            bool notIndDB = false;
            int startIndex = splitValues.Length;
            while (!notIndDB && startIndex >= 0)
            {
                notIndDB = Check(BuildString(startIndex--, splitValues));                
            }
        }
        private string BuildString(int startIndex, string[] splitValues)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = startIndex; i <= splitValues.Length -1; i++)
            {
                builder.Append((i != splitValues.Length -1 ? splitValues[i] + "_" : splitValues[i]));
            }
            return builder.ToString();
        }
        private bool Check(string parameter)
        {
            bool isFound = false;
            //Check if string is in db
            return isFound;
        }
