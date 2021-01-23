    public class SongInfo
    {
        public string CS { get; set; }
        public string AR { get; set; }
        public string HP { get; set; }
        public string STAR { get; set; }
        public string LENGTH { get; set; }
        public string BPM { get; set; }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            SongInfo song = new SongInfo();
            HtmlDocument doc = new HtmlDocument();
            doc.Load("da.html");
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//td[@width='0%']");
            foreach (HtmlNode n in nodes)
            {
                if (n.InnerText.ToLower().Contains("circle size:"))
                {
                    song.CS = n.InnerText+ " " + Convert.ToString(AlmostAnything(n.NextSibling));
                }
                if (n.InnerText.ToLower().Contains("approach rate:"))
                {
                    song.AR = n.InnerText + " " + Convert.ToString(AlmostAnything(n.NextSibling));
                }
                if (n.InnerText.ToLower().Contains("hp drain:"))
                {
                    song.HP = n.InnerText + " " + Convert.ToString(AlmostAnything(n.NextSibling));
                }
                if (n.InnerText.ToLower().Contains("star difficulty:"))
                {
                    song.STAR = n.InnerText + " " + Convert.ToString(AlmostAnything(n.NextSibling));
                }
                if (n.InnerText.ToLower().Contains("length:"))
                {
                    song.LENGTH = NextSiblingText(n);
                }
                if (n.InnerText.ToLower().Contains("bpm:"))
                {
                    song.BPM = NextSiblingText(n);
                }
            }
            PrintSong(song);  
        }
        private static string NextSiblingText(HtmlNode n)
        {
            return n.NextSibling.InnerText;
        }
        private static int AlmostAnything(HtmlNode n)
        {
            string starfield="" , activefield = "";
            HtmlDocument temp = new HtmlDocument();
            temp.LoadHtml(n.InnerHtml);
            foreach (HtmlNode hN in temp.DocumentNode.SelectNodes("//div"))
            {
                if (hN.GetAttributeValue("class", "not found") == "starfield")
                {
                    starfield = hN.GetAttributeValue("style", "style not found");
                }
                if (hN.GetAttributeValue("class", "not found") == "active")
                {
                    activefield = hN.GetAttributeValue("style", "style not found");
                }
            }
            double result = ConvertStringToNum(starfield) / ConvertStringToNum(activefield);
            return Convert.ToInt32(result);
        }
        private static double ConvertStringToNum(string s)
        {
            string temp="";
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsNumber(s[i]))
                {
                    temp += s[i];
                    for (i = i + 1; i < s.Length; i++)
                    {
                        if (Char.IsNumber(s[i]))
                        {
                            temp += s[i];
                        }
                        else
                        {
                            return Convert.ToDouble(temp);
                        }
                    }
                }
            }
            return -1;
        }
        private static void PrintSong(SongInfo s)
        {
            Console.WriteLine(s.CS);
            Console.WriteLine(s.AR);
            Console.WriteLine(s.HP);
            Console.WriteLine(s.STAR);
            Console.WriteLine(s.LENGTH);
            Console.WriteLine(s.BPM);
        }
    }
