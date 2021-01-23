    Regex regex1 = new Regex("\\[([1-9]+?)\\]\\s<\\w+?>.+\\n\\[([\\s\\S]+?)\\]");
                MatchCollection matches = regex1.Matches(logMessage);
    
                foreach (Match match in matches)
                {
                    String indexField = match.Groups[1].Value;
                    String message = match.Groups[2].Value.Trim();
                    if (String.IsNullOrEmpty(message) == false)
                    {
                        Regex regex2 = new Regex("Name:\\s(.+?)\\n[\\s\\S]*?(Error:|Status:)\\s+?(.+?)$");
                        Match messageMatch = regex2.Match(message);
                        String name = messageMatch.Groups[1].Value.Trim();
                        String statusErrore = messageMatch.Groups[3].Value.Trim();
                    }
                }
