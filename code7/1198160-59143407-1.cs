            string emailStr="MyEmailStr@MailName.com";
            string[] parts = emailStr.Split('@');
            string star = string.Empty;
            string FirstCharEmailName = "";
            for (int i = 0; i < parts[0].Length; i++)
            {
                if (i == 0)
                {
                    FirstCharEmailName=parts[0].First().ToString();
                }
                star += "*";
            }
            return FirstCharEmailName + star +"@" + parts[1];
