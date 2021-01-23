    string text = "indra";
    byte[] asciiBytes = Encoding.ASCII.GetBytes(text);
    char[] result = new char[text.Length];
    for (int i = 0; i < text.Length; i++)
    {
        int vout = Convert.ToInt32(asciiBytes[i]);
        int c = (int)BigInteger.ModPow(vout, e, n);
        char cipher = Convert.ToChar(c);
        result[i] = cipher;
    }
    textBox2.Text = new string(result);
