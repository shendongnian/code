    List<Color> getRtfColorTable(RichTextBox RTB)
    {   // \red255\green0\blue0;
        List<Color> colors = new List<Color>();
        string tabString = @"\colortbl ;"; 
        int ct0 = RTB.Rtf.IndexOf(tabString);
        if (ct0 >= 0)
        {
            ct0 += tabString.Length;
            int ct1 = RTB.Rtf.IndexOf(@"}", ct0);
            var table = RTB.Rtf.Substring(ct0, ct1 - ct0).Split(';');
            foreach(string t in table)
            {
                var ch = t.Split('\\');
                if (ch.Length == 4)
                {
                    int r = Convert.ToInt16(ch[1].Replace("red", ""));
                    int g = Convert.ToInt16(ch[2].Replace("green", ""));
                    int b = Convert.ToInt16(ch[3].Replace("blue", ""));
                    colors.Add(Color.FromArgb(255, r, g, b));
                }
            }
        }
        return colors;
    }
