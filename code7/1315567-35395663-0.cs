     public string ReplaceData(List<ListData> list, string emailBody)
        {
            foreach (var item in list)
            {           
                foreach (var property in item.GetType().GetProperties())
                {                 
                    string stringToReplace = string.Format("<{0}>", property.Name.ToString());
                    string valueToReplaceWith = property.GetValue(item, null).ToString();
                    emailBody = emailBody.Replace(stringToReplace, valueToReplaceWith);
                }               
            }
