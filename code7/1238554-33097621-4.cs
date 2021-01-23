    public async Task<CSPFEnumration.ProcedureResult> GenerateFaxFile(
        string Daftar_No,
        string Channelno,
        string NationalCode)
    {
        IEnumerable<string> commandStrings = Regex.Split(
            script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        Connect();
        foreach (var commandString in commandStrings)
         {
            if (commandString.Trim() != "")
            {
                using (var command = new SqlCommand(commandString, Connection))
                    {
                        Task<int> task = command.ExecuteNonQuery();
                        // while the command is being executed
                        // you can do other things.
                        // when you need the result: await
                        int result = await task;
                        // if useful: interpret result;
                    }
                }
            }
            DisConnect();
            ... etc.
    }
