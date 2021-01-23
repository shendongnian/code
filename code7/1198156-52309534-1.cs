    public static string MaskEmail(this string email)
        {            
            var emailsplit = email.Split('@');
            var newsplit = emailsplit[1].Split('.');
            char[] array1 = emailsplit[0].ToCharArray();
            char[] array2 = newsplit[0].ToCharArray();
            var output = "";
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1.Length > 4)
                {
                    if (i == 0 || i == array1.Length - 1 || i == array1.Length - 2)
                    {
                        output += array1[i];
                    }
                    else
                    {
                        output += "*";
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        output += array1[i];
                    }
                    else
                    {
                        output += "*";
                    }
                }              
            }
            output += "@";
            for (int i = 0; i < array2.Length; i++) output += "*";
            for (int i = 1; i < newsplit.Length; i++) output += "." + newsplit[i];
            
            return output;
        }
