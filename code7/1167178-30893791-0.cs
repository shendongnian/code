    public class SetUserName : Map
        {
            internal override string Pattern { get { return @"request.setUsername\(""(.*)""\)"; } }
    
            public override void Match(string line)
            {
                Match match = Regex.Match(line, Pattern);
                if (match.Success)
                {
                    Success = true;
                    CodeLines = new Code<CodeLine>
                    {new CodeLine("request.Username = \"" + match.Groups[1].Value + "\"")};
                }
            }
        }
