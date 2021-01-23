    public static List<string> ExtractEmailAddresses(string text)
    {
        var items = new List<string>();
        if (String.IsNullOrEmpty(text))
        {
            return items;
        }
        int start = 0;
        bool foundAt = false;
        int comment = 0;
        for (int i = start; i < text.Length; i++)
        {
            switch (text[i])
            {
                case '@':
                    if (comment == 0) { foundAt = true; }
                    break;
                case '(':
                    comment++;
                    break;
                case ')':
                    comment--;
                    break;
                case ',':
                    HandleLastBlock(i);
                    break;
            }
        }
        HandleLastBlock(text.Length);
        return items;
        void HandleLastBlock(int end)
        {
            if (comment == 0 && foundAt && start < end - 1)
            {
                var email = new System.Net.Mail.MailAddress(text.Substring(start, end - start));
                items.Add(email.Address);
                start = end + 1;
                foundAt = false;
            }
        }
    }
