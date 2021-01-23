                static bool PasswordComplexityPolicy()
            {
                
                var tempFile = Path.GetTempFileName();
                Process p = new Process();
                p.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\secedit.exe");
                p.StartInfo.Arguments = String.Format(@"/export /cfg ""{0}"" /quiet", tempFile);
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.WaitForExit();
                var file = IniFile.Load(tempFile);
                IniSection systemAccess = null;
                var MaxPasswordAgeString = "";
                var MaxPasswordAge = 0;
                return file.Sections.TryGetValue("System Access", out systemAccess)
                    && systemAccess.TryGetValue("MaxPasswordAge", out MaxPasswordAgeString)
                    && Int32.TryParse(MaxPasswordAgeString, out MaxPasswordAge)
                    && MaxPasswordAge <= 90;
            }
