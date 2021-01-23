    public class FileGenEventArgs : EventArgs
    {
        public string ProcedureResult { get; set; }
    }
    public class GenerateFile
    {
        public event EventHandler<FileGenEventArgs > fileCreated;
        public GenerateFile()
        {
            // subscribe for this event somewhere in your code.
            fileCreated += GenerateFile_fileCreated;
        }
        void GenerateFile_fileCreated(object sender, FileGenEventArgs args)
        {            
            // .. do something with  args.ProcedureResult
        }
        private void FileCheck()
        {
            Thread.Sleep(2000); // delay
            fileCreated(this, new FileGenEventArgs()
            {
                ProcedureResult = File.Exists(FaxFilePath) ?
                  CSPFEnumration.ProcedureResult.Success :
                     CSPFEnumration.ProcedureResult.Error
            });            
        }
        public void GenerateFaxFile(string Daftar_No, string Channelno, string NationalCode)
        {
            try
            {
                // this .Sleep() represents your sql operation so change it
                Thread.Sleep(1000);
                new Thread(FileCheck).Start();
            }
            catch (Exception ex)
            {
                InternalDatabase.GetInstance.InsertToPensionOrganizationException(ex);  
            }
        }
    }
