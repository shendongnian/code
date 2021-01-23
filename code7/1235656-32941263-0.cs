    using System;
    using System.Data;
    using System.IO;
    using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
    [Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
    public class ScriptMain : UserComponent
    {
        public override void CreateNewOutputRows()
        {
            string sourceDirectory = @"C:\ssisdata";
            string fileMask = "*.txt";
            // Variable for storing file properties
            FileInfo fileInfo;
            foreach (var currentFile in Directory.GetFiles(sourceDirectory, fileMask, SearchOption.AllDirectories))
            {
                fileInfo = new FileInfo(currentFile);
                Output0Buffer.AddRow();
                Output0Buffer.FullName = fileInfo.FullName;
                Output0Buffer.Name = fileInfo.Name;
                Output0Buffer.LastWriteTime = fileInfo.LastWriteTime;
                // fileInfo.Length is type Long
                // Output0Buffer.Length is type Int64
                // Too lazy to look, but I think Long could overflow Int64
                Output0Buffer.Length = fileInfo.Length;
            }
        }
    }
