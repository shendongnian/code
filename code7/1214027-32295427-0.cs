            string checkMacOutcome = "";
            var psi = new System.Diagnostics.ProcessStartInfo(ejecutable_CheckMac, archivo_temporal);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            using (var proc = System.Diagnostics.Process.Start(psi))
            {
                using (StreamReader sr = proc.StandardOutput)
                {
                    checkMacOutcome = sr.ReadToEnd();
                }
            }
            
            StreamWriter writetext = new StreamWriter(archivo_resultado);
            writetext.WriteLine(checkMacOutcome);
            writetext.Close();
