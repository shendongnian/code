    // using Microsoft.SqlServer.Management.SqlParser.Parser;
    // ...
    var sql = File.ReadAllText(@"*.sql");
    var scanner = new Scanner(new ParseOptions());
    int scannerState = 0;
    scanner.SetSource(sql, 0);
    var allTokens = new List<MyToken>();
    MyToken curToken = null;
    do
    {
        curToken = MyToken.GetNext(scanner, sql, ref scannerState);
        allTokens.Add(curToken);
    }
    while (curToken.Value != Tokens.EOF);
    //...
    public class MyToken
    {
        public readonly string SourceSQL;
        public readonly Tokens Value;
        public readonly string Text;
        public readonly int ScannerState;
        public readonly int Start;
        public readonly int End;
        public readonly bool IsPairMatch;
        public readonly bool IsExecAutoParamHelp;
    
        private MyToken(string SourceSQL, int tokenId, int ScannerState, int Start, int End, bool IsPairMatch, bool IsExecAutoParamHelp)
        {
            this.SourceSQL = SourceSQL;
            this.Value = (Tokens)tokenId;
            if (this.Value != Tokens.EOF)
            {
                this.Text = SourceSQL.Substring(Start, End - Start + 1);
            }
    
            this.ScannerState = ScannerState;
            this.Start = Start;
            this.End = End;
            this.IsPairMatch = IsPairMatch;
            this.IsExecAutoParamHelp = IsExecAutoParamHelp;
        }
    
        public static MyToken GetNext(Scanner scanner, string SourceSQL, ref int ScannerState)
        {
            int start, end;
            bool isPairMatch, isExecAutoParamHelp;
            int tokenId = scanner.GetNext(ref ScannerState, out start, out end, out isPairMatch, out isExecAutoParamHelp);
            return new MyToken(SourceSQL, tokenId, ScannerState, start, end, isPairMatch, isExecAutoParamHelp);
        }
    
        public override string ToString()
        {
            return String.Format("{0}:{1}", this.Value, this.Text);
        }
    }
