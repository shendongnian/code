    public void ExecuteCommands(string Directoria, CdpsiUpdateSql Updater, CdpsiUpdateSqlparser parser, string Log, IProgress<Result> progress)
    {
        //... your code
        foreach (string str in list)
        {
            int[] numArray2 = this.ExecuteCommand(parser.Parser(str), Updater, str, Log);
            // your code
            Result result = new Result
            {
                File = str,
                Error = Errados,
                Successes = Certos
            };
            progress.Report(result);
        }
    }
