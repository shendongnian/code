            StringBuilder newText = new StringBuilder();
            for (int i = 0; i < MailItem.Body.Length; i++)
            {
                if (a[i] != '\u200b')
                {
                    newText.Append(a[i]);
                }
            } 
