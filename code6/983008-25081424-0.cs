        public static void RunPowerCFGReport()
        {
            Process.Start(BUConfig.CurrentPath + @"\PowerCFG");
        }
        public static string GetSubGroupGuid(string AppPath)
        {
            string[] lines = File.ReadAllLines(AppPath);
            string guid = lines.Where(s => s.Contains("Power buttons and lid")).First();
            string[] loops = guid.Split(':') ;
            string pr = loops[1].Replace(" (Power buttons and lid)", "");
            return pr.Trim();
        }
        public static string GetPowerSchemeGuid(string AppPath)
        {
            string[] lines = File.ReadAllLines(AppPath);
            string guid = lines.Where(s => s.Contains("Power Scheme GUID:")).First();
            string[] loops = guid.Split(':');
            string pr = loops[1].Replace("  (Balanced)", "");
            return pr.Trim();
        }
        public static string GetPowerSettingGUID(string AppPath)
        {
            string[] lines = File.ReadAllLines(AppPath);
            string guid = lines.Where(s => s.Contains("  (Lid close action)")).First();
            string[] loops = guid.Split(':');
            string pr = loops[1].Replace("  (Lid close action)", "");
            return pr.Trim();
        }
        public static void SetPowerCFGValues(string _pathFile, string _currentPowerSchemeGuid, string      _currentPowerSettingGuid, string _currentGroupGuid)
        {
            try
            {
                StreamWriter wr;
                string currentCommand = File.ReadAllText(_pathFile);
                currentCommand = currentCommand.Replace("[powerschemeGUID]", _currentPowerSchemeGuid);
                currentCommand = currentCommand.Replace("[putsubgroupGUID]", _currentGroupGuid);
                currentCommand = currentCommand.Replace("[putpowersettingGUID]", _currentPowerSettingGuid);
                wr = new StreamWriter(_pathFile);
                wr.WriteLine(currentCommand);
                wr.Close();
            }
            catch(Exception ex)
            { 
            
            }
        }
        public static void SetLIDAction(string _lidAction)
        {
            Process.Start(BUConfig.CurrentPath + @"\Test.Bat");
        }
        public static void ResetLIDFile()
        {
            string commandtmeplate = "call Powercfg –SETACVALUEINDEX [powerschemeGUID] [putsubgroupGUID] [putpowersettingGUID] 000";
            StreamWriter wr = new StreamWriter(BUConfig.CurrentPath + @"\Test.Bat");
            wr.WriteLine(commandtmeplate);
        }
