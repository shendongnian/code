    if (IsUnicode(str))
    {
       writer.Write((uint)str.Length + 1);
       writer.Write(Encoding.Unicode.GetBytes(str));
    }
    private bool IsUnicode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;
            foreach (char c in text)
            {
                if (c > 0x7F)
                    return true;
            }
            return false;
        }
