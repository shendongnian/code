    public List<string> ExtractEmails(string emails)
    {
        List<string> result = new List<string>();
        while (true)
        {
            int position_of_at = emails.IndexOf("@");
            if (position_of_at == -1)
            {
                break;
            }
            int position_of_comma = emails.IndexOf(",", position_of_at);
            if (position_of_comma == -1)
            {
                result.Add(emails);
                break;
            }
            string email = emails.Substring(0, position_of_comma);
            result.Add(email);
            emails = emails.Substring(position_of_comma + 1);
        }
        return result;
    }
