        private string convertCSV(string pCSVtext)
        {
            string returnText = "";
            pCSVtext = pCSVtext.Replace(" ", "");
            string[] split = pCSVtext.Split(Convert.ToChar(","));
            for (int i = 0; i < split.Length; i++)
            {
                returnText += "\"" + split[i].ToString() + "\"";
                if(i != split.Length - 1)
                {
                    returnText += ",";
                }
                
            }
            return returnText;
        }
    string[] csvVals = new string[5] { "George", "Washington", "Was", "A", "President" };
    
            public string convertCSV_Array(Array pCSVvals)
            {
                string returnString = "";
                int i = 0;
                foreach(string val in pCSVvals)
                {
                    returnString += "\"" + val + "\"";
                    if (i != pCSVvals.Length - 1)
                    {
                        returnString += ",";
                    }
                    i++;
                }
                return returnString;
            }
