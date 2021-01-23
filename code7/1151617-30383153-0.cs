    public static string GenerateJson<T>(List<T> obj)
        {
            var returnString = "[";
            var listCounter = 0;
            foreach (var item in obj)
            {
                var counter = 0;
                var props = item.GetType().GetProperties();
                returnString += "{";
                foreach (var prop in props)
                {
                    returnString += "\""+prop.Name+"\":" + "\""+prop.GetValue(item,null)+"\"";
                    counter++;
                    if (counter != props.Count())
                        returnString += ",";
                }
                returnString += "}";
                listCounter++;
                if (listCounter != obj.Count())
                    returnString += ",";
                
            }
            returnString += "]";
            return returnString;
        }
