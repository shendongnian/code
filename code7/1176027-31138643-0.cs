    using System;
    using System.IO;
    
    namespace EPPlus_AutoSave_Excel_Export
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo outputDir = new DirectoryInfo(@"c:\temp\Auto-Save");
    
                if (!outputDir.Exists) 
                    throw new Exception("outputDir does not exist!");
    
                Sample_Auto_Save obj = new Sample_Auto_Save(outputDir, 50000);
                obj.ExportWithAutoSave();
            }
        }
    }
