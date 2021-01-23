    static string DecodeQuotedPrintable (string input, string charset)
    {
        var decoder = new QuotedPrintableDecoder ();
        var buffer = Encoding.ASCII.GetBytes (input);
        var output = new byte[decoder.EstimateOutputLength (buffer.Length)];
        int used = decoder.Decode (buffer, 0, buffer.Length, output);
        var encoding = Encoding.GetEncoding (charset);
        return encoding.GetString (output, 0, used);
    }
