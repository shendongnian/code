    Regex regex = new Regex(@"event ACTION\[(?<type>[^\]]*)\]::OnProc {? ?;(?<msg>[^}]*)}");
    List<ScriptData> Script = new List<ScriptData>();
    string ScriptTxt1 = List.ScriptComp[0].CompScrTxt;
    //convert first script
    foreach (Match match in regex.Matches(ScriptTxt1))
    {
        Script.Add(new ScriptData(match.Groups["type"].Value, match.Groups["msg"].Value));
    }
    public class ScriptData
    {
        public string Type { get; private set; }
        public string ScriptMessage { get; private set; }
        public ActionScriptData(string type, string msg)
        {
            Type = type;
            ScriptMessage = msg;
        }
        public ScriptData()
        {
            Type = null;
            ScriptMessage = null;
        }
    }
