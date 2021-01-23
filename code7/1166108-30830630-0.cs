    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            public static Process ShellStart(string aCmd, TextWriter aOutputWriter = null, TextWriter aErrorWriter = null)
            {
                var vProcess = new Process();
                var vStartInfo = vProcess.StartInfo;
                vStartInfo.FileName = Path.Combine(Environment.SystemDirectory, "CMD.EXE") ;
                var vCmd =  "/Q /C ";
                vStartInfo.Arguments = vCmd + "\"" + aCmd + "\"";
                vStartInfo.UseShellExecute = false;
                vStartInfo.CreateNoWindow = true;
                if (aOutputWriter != null)
                {
                    vProcess.OutputDataReceived += (p, a) =>
                    {
                        if (a.Data != null)
                        {
                            aOutputWriter.WriteLine(a.Data);
                        }
                    };
                    vStartInfo.RedirectStandardOutput = true;
                    vStartInfo.RedirectStandardInput = true;
                }
                if (aErrorWriter != null)
                {
                    vProcess.ErrorDataReceived += (p, a) =>
                    {
                        if (a.Data != null)
                        {
                            aErrorWriter.WriteLine(a.Data);
                        }
                    };
                    vStartInfo.RedirectStandardError = true;
                    vStartInfo.RedirectStandardInput = true;
                }
                if (!vProcess.Start()) return null;
                if (aOutputWriter != null || aErrorWriter != null)
                    vProcess.Exited += (s, e) =>
                    {
                        if (aOutputWriter != null) aOutputWriter.Flush();
                        if (aErrorWriter != null) aErrorWriter.Flush();
                    };
                if (aOutputWriter != null) vProcess.BeginOutputReadLine();
                if (aErrorWriter != null) vProcess.BeginErrorReadLine();
                if (vStartInfo.RedirectStandardInput) vProcess.StandardInput.Close();
                return vProcess;
            }
    
            public static int ShellExec(string aCmd, TextWriter aOutputWriter = null, TextWriter aErrorWriter = null)
            {
                var vResult = -1;
                using (var vProcess = ShellStart(aCmd, aOutputWriter, aErrorWriter))
                    if (vProcess != null)
                    {
                        vProcess.WaitForExit();
                        vResult = vProcess.ExitCode;
                        vProcess.Close();
                    }
                return vResult;
            }
    
            public static IEnumerable<String> SplitLines(string s)
            {
                string vLine;
                if (!String.IsNullOrEmpty(s))
                    using (var vReader = new StringReader(s))
                        while ((vLine = vReader.ReadLine()) != null)
                        {
                            yield return vLine;
                        }
            }
    
            public static string ShellExecGetLastLine(string aCmd)
            {
                var vOutput = new StringBuilder();
                using (TextWriter vWriter = new StringWriter(vOutput))
                {
                    ShellExec(aCmd, vWriter, null);
                    return SplitLines(Convert.ToString(vOutput).Trim()).LastOrDefault();
                }
            }
            static void Main(string[] args)
            {
                Console.WriteLine(ShellExecGetLastLine("attrib"));
            }
        }
    }
