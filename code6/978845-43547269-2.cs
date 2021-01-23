    public class GeneralMethods
    {
        public static string[] UnWrapObjects(object obj)
        {
            JObject o = JObject.Parse(obj.ToString());
            string[] str = new string[o.Count];
            for (int i = 0; i < o.Count; i++)
            {
                string var = "obj" + (i + 1).ToString();
                str[i] = o[var].ToString(); 
            }
            return str;
        }
    }
