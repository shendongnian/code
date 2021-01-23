        public static string[] replacer(Dictionary<string,string> dic, string data) 
        {
            foreach (KeyValuePair<string,string> entry in dic)
            {
                data = data.Replace(entry.Key, entry.Value);
            }
            string[] delimiters = new string[] { Environment.NewLine, " " };
            string[] lines =  data.Split(delimiters ,StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }
    public static string[] wrapper(string[] data, string tag)
    {
       string tagOpen, tagClose;
       tagOpen = "<" + tag + ">";
       tagClose = "</" + tag + ">";
       for(int i = 0; i < data.Length; i++)
       {
           data[i] = tagOpen + data[i] + tagClose;
       }
       
       return data;
    }
    public static string combiner(string[] data)
    {
       string res = string.Empty;
       for(int i = 0; i < data.Length; i++)
       {
           res += data[i] + Environment.NewLine;
       }
       return res;
    }
