    Lock(@"c:\file",
            (f) =>
                {
                    try
                    {
                        f.Write(buf, 0, buf.Length);
                    }
                    catch(IOException ioe)
                    {
    // handle IOException
                    }
                });
