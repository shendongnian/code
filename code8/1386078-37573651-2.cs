    public void ExecuteCommands(string Directoria, CdpsiUpdateSql Updater, CdpsiUpdateSqlparser parser, string Log, Action<int[]> getResults)
    {
        string[] numArray1 = new string[3];
        List<string> list = ((IEnumerable<string>)Directory.GetFiles(Directoria, "*.sql", SearchOption.TopDirectoryOnly)).Select(f =>
        {
            string[] strArray = Path.GetFileName(f).Split('_');
            int result;
            if (strArray.Length < 1 || !int.TryParse(strArray[0], out result))
                result = -1;
            var data = new
            {
                File = f,
                Version = result
            };
            return data;
        }).Where(f => f.Version > -1).OrderBy(f => f.Version).Select(f => f.File).ToList<string>();
        foreach (string str in list)
        {
            int[] numArray2 = this.ExecuteCommand(parser.Parser(str), Updater, str, Log);
            int Certos = Convert.ToInt32(numArray1[0]);
            int Errados = Convert.ToInt32(numArray1[1]);
            Certos += numArray2[0];
            Errados += numArray2[1];
            numArray1[0] = Certos.ToString();
            numArray1[1] = Errados.ToString();
            numArray1[2] = str;
            //new code
            if(getResults!=null)
            {
                getResults(numArray1);
            }
        }
    }
