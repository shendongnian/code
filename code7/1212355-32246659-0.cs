    class StrangeParser
    {
        public static readonly Regex LINE_REGEX = new Regex("^\\s*([a-zA-Z0-9_]+)\\s*\\:\\s*\"(.*)\"\\s*$", RegexOptions.Multiline);
        public static Dictionary<string, string> ParseStr(string str)
        {
            var m = LINE_REGEX.Matches(str);
            var res = new Dictionary<string, string>();
            foreach (Match item in m)
            {
                res.Add(item.Groups[1].Value, item.Groups[2].Value);
            }
            return res;
        }
        static void Main(string[] args)
        {
            foreach (var item in ParseStr(@"
    {
        behavior_capture_widget: ""<div id=""ndwc""><noscript><input type=""hidden"" id=""ndpd-spbd"" name=""ndpd-spbd""                            value=""ndpds~~~2.4177.112540pPaGJYVmt5WCtndGlUiUcRt3aSOPQ,,""></noscript></div> <script type=""text/javascript""></script>""
        customer_session_data:   ""2.4177.112540.1399312572.2.mFDzrW_JJeu-C_H45O5ADQ""
        customer_cookie_data:    ""2.4177.112540.1399312572.2.XYjAsjFsOVHFXBGNnnHc-g,,.""
    }
    "))
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
