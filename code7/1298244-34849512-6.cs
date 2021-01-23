           public static string GetJsonFileString(string section)
        {
            try
            {
                string Data;
                if (!string.IsNullOrEmpty(section))
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath(@"~/Dictionary/") + section + ".json";
                    Data = File.ReadAllText(filePath);
                }
                else {
                    Data = "Default";
                }
                return Data;
            }
            catch
            {
                return null;
            }
        }
