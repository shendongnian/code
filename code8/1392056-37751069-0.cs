    public static string ReturnNoBlankLinks(string emptyLineString)
            {
                using (StringReader sR = new StringReader(emptyLineString))
                {
                    string curLine = String.Empty;
                    while ((curLine = sR.ReadLine()) != null)
                    {
                        if (!String.IsNullOrWhiteSpace(curLine))
                        {
                            doSomething();
                        }
                    }
                }
            }
