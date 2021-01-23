    var text =
                @"this a asdf asdf asdf asdf asdf wdbwbwrthwrthw rthwrth wth wrt h wrn wrnbfb  wbwbwbb s  jkvjv j j o o  , , mfnfnsxuiua sdf asdfas dfasd f
    asdf asd fasdf asdf asdf asdf asd fasdf asd fasdf asdf asdf asdf asdf asdf asd fasdf as
    df asd fasdf asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf ";
            
            var sb = new StringBuilder();
            var currentLine = String.Empty;
            var split = text.Split(' ');
            foreach (var s in split)
            {
                if (s.Length >= 80)
                {
                    if (!String.IsNullOrEmpty(currentLine))
                    {
                        sb.AppendLine(currentLine);
                        currentLine = "";
                    }
                    sb.AppendLine(s);
                    continue;
                }
                if ((String.Format("{0} {1}", currentLine, s).Length > 80))
                {
                    sb.AppendLine(currentLine);
                    currentLine = "";
                }
                currentLine += s + " ";
            }
            if (!String.IsNullOrEmpty(currentLine))
            {
                sb.AppendLine(currentLine);
            }
            var final = sb.ToString();
