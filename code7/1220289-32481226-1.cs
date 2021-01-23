    using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
    using (Stream stream = response.GetResponseStream())
    {
        int b;
        string s = string.Empty;
        string hex = string.Empty;
        bool candidate = false;
        while ((b = stream.ReadByte()) >= 0)
        {
            if (b == 13 || b == 10)
            {
                if (candidate)
                {
                    // see a program output or put a breakpoint here and inspect the "hex",
                    // verify in "s" that it's the file youlook for
                    Console.WriteLine(s + " = " + hex);
                }
                hex = string.Empty;
                s = string.Empty;
                candidate = false;
            }
            else
            {
                hex += b.ToString("X2") + ",";
                s += (char)b;
                if (b >= 128)
                {
                    candidate = true;
                }
            }
        }
    }
