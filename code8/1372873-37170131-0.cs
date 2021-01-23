    using System;
    using System.IO;
    using System.IO.Compression;
    
    namespace SOTesting
    {
        [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
        public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
        {
    
            public void Main()
            {
                try
                {
                    // I couldn't get the gz to open afterward 
                    ZipFilesG(); // GZipStream attempt 
                    
                    //** !! Must add reference to System.IO.Compression.FileSystem for this to work
                    ZipFilesZ(); // ZipArchive attempt; this worked well for me
                     
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
                catch
                {
                    Dts.TaskResult = (int)ScriptResults.Failure;
                }
            }
    
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
    
            public void ZipFilesG()
            {
                // You may need to adjust these a bit
                string xlsFileName = "*.xlsx"; // Dts.Variables["User::ZipFileMask"].Value.ToString();
                string zipFileName = "SSIS.gz"; // Dts.Variables["User::ZipFileName"].Value.ToString();
                string zipFilePath = @"C:\TEMP\SSIS"; // Dts.Variables["User::ZipFilePath"].Value.ToString();
                string fullFilePath = zipFilePath + "\\" + zipFileName;
    
                MessageBox.Show($"fullFilePath: {fullFilePath}");
    
                //Delete the zip file
                if (File.Exists(fullFilePath)) File.Delete(fullFilePath);
    
                DirectoryInfo filePath = new DirectoryInfo(zipFilePath);
    
                try
                {
                    FileStream compressedFileStream = new FileStream(fullFilePath, FileMode.Append);
                    GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress);
                    foreach (FileInfo fileToCompress in filePath.GetFiles(xlsFileName))
                    {
                        using (FileStream originalFileStream = fileToCompress.OpenRead())
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                    compressionStream.Close();
                    compressedFileStream.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            public void ZipFilesZ()
            {
                // You may need to adjust these a bit
                string xlsFileName = "*.xlsx"; // Dts.Variables["User::ZipFileMask"].Value.ToString();
                string zipFileName = "SSIS.zip"; // Dts.Variables["User::ZipFileName"].Value.ToString();
                string zipFilePath = @"C:\TEMP\SSIS"; // Dts.Variables["User::ZipFilePath"].Value.ToString();
                string fullFilePath = zipFilePath + "\\" + zipFileName;
    
                //Delete the zip file
                if (File.Exists(fullFilePath)) File.Delete(fullFilePath);
    
                DirectoryInfo filePath = new DirectoryInfo(zipFilePath);
    
                try
                {
                    foreach (FileInfo fileToCompress in filePath.GetFiles(xlsFileName))
                    {
                        using (ZipArchive archive = ZipFile.Open(fullFilePath, ZipArchiveMode.Update))
                        {
                            archive.CreateEntryFromFile(fileToCompress.FullName, fileToCompress.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
