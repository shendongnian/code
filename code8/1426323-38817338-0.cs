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
