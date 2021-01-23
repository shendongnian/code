        public string[] getHtmlSplitted(String text)
        {
            var list = new List<string>();
            var pattern = "(<b>|</b>)";
            var isInTag = false;            
            var inTagValue = String.Empty;
            foreach (var subStr in Regex.Split(text, pattern))
            {
                if (subStr.Equals("<b>"))
                {
                    isInTag = true;
                    continue;
                }
                else if (subStr.Equals("</b>"))
                {
                    isInTag = false;
                    list.Add(String.Format("<b>{0}</b>", inTagValue));
                    continue;
                }
                if (isInTag)
                {
                    inTagValue = subStr;
                    continue;
                }
                list.Add(subStr);
            }
            return list.ToArray();
        }
