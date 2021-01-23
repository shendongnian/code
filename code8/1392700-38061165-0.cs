        StringBuilder prefixData = new StringBuilder();
        prefixData.Append("--");
        prefixData.Append(boundary);
        prefixData.Append(Environment.NewLine);
        prefixData.Append("Content-Disposition: form-data; name=\"media\"");
        prefixData.Append(Environment.NewLine);
        prefixData.Append(Environment.NewLine);
        byte[] prefix = Encoding.UTF8.GetBytes(prefixData.ToString());
    
        StringBuilder suffixData = new StringBuilder();
        suffixData.Append(Environment.NewLine);
        suffixData.Append("--");
        suffixData.Append(boundary);
        suffixData.Append("--");
        byte[] suffix = Encoding.UTF8.GetBytes(suffixData.ToString());
