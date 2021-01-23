    public void ExecuteCommands(string Directories, CdpsiUpdateSql Updater, CdpsiUpdateSqlparser parser, string Log, IProgress<Result> progress)
    {
        //Remove this line
        //Result FinalResult = new Result();
    
        //... your code as is... bla bla bla
        foreach (string str in list)
        {
            int[] numArray2 = this.ExecuteCommand(parser.Parser(str), Updater, str, Log);
            int Succcesses = numArray2[0];
            int Errors = numArray2[1];
            //new line
            Result FinalResult = new Result();
            FinalResult.File = str;
            FinalResult.Errors = Errors;
            FinalResult.Successes = Errors;
            progress.Report(FinalResult);
            
        }
    }
