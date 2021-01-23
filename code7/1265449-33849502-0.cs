            string s = "This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. ";
            s += "This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. ";
            s += "This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. This is a rather long text. ";
            var words = s.Split(new char[] { ' ' });
            int maxLineCount = 35;
            var sb=new System.Text.StringBuilder();
            string part=words[0];
            int i=1;
            while (true) {
                if (i >= words.Length)
                    break;
                if ((part + " " + words[i]).Length < maxLineCount)
                    part += " " + words[i];
                else {
                    sb.AppendLine(part);
                    part = words[i];
                }
                i++;
            }
            var result = sb.ToString();
