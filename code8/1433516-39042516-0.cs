    bool Get(string s, int i)
    {
        bool result = false;
        int index = s.IndexOf(i.ToString());
        if (index >= 0)
        {
            if (index == 0)
            {
                if (i.ToString().Length == s.Length)
                {
                    result = true;
                }
                else
                {
                    if (char.IsNumber(s.ElementAt(index + i.ToString().Length)))
                    {
                        result = false;
                    }
                }
            }
            else
            {
                if (char.IsNumber(s.ElementAt(index - 1)))
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
        }
        else
        {
            result = false;
        }
        return result;
    }
