    private readonly Regex m_Regex = new Regex(@"^(?<changeset>\d+)(?<codeLine>.*)", RegexOptions.Compiled | RegexOptions.Multiline);
    
    public List<Changeset> GetAnnotations(string filepath, string codeText)
        {
            var versionControlServer = CreateVersionControlServer();
        
            return m_Regex.Matches(ExecutePowerTools(filepath))
                .Cast<Match>()
                .Where(m => m.Groups["codeLine"].Value.Contains(codeText))
                .Select(v => versionControlServer.GetChangeset(int.Parse(v.Groups["changeset"].Value), false, false))
                .ToList();
        }
        
        private static VersionControlServer CreateVersionControlServer()
        {
            var projectCollection = new TfsTeamProjectCollection(new Uri(@"TFS URL"));
            var versionControlServer = projectCollection.GetService<VersionControlServer>();
            return versionControlServer;
        }
        
        private static string ExecutePowerTools(string filepath)
        {
            using (var process = Process.Start(TfptLocation, string.Format("annotate /noprompt {0}", filepath)))
            {
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd();
            }
        }
        
           
