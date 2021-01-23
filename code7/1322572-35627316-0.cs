            private string GetMoveStatusListString<T>(IEnumerable<T> list) where T : struct 
            {
                string outValue = null;
                if (list != null)
                {
                    outValue = "";
                    // Parse the string list to get enum values into a list
                    List<string> tempStatusList = new List<string>();
                    foreach (object sts in list)
                    {
                        T enumValue;
                        if (Enum.TryParse<T>(sts.ToString(), out enumValue))
                        {
                            tempStatusList.Add(enumValue.ToString());
                        }
                    }
    
                    outValue = string.Join(",", tempStatusList);
                }
                return outValue;
            }
