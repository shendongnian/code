    using System;
    using WinSCP;
 
    class Example
    {
        public static int Main()
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = EdiConfiguration.FtpIpAddressOrHostName,
                UserName = EdiConfiguration.FtpUserName,
                Password = EdiConfiguration.FtpPassword,
                SshHostKeyFingerprint = EdiConfiguration.SshHostKeyFingerprint,
                PortNumber = EdiConfiguration.FtpPortNumber
            };
            using (Session session = new Session())
            {
                session.Open(sessionOptions);
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                // Download the files in the OUT directory.
                TransferOperationResult transferOperationResult = session.GetFiles(EdiConfiguration.FtpDirectory, EdiConfiguration.IncommingFilePath, false, transferOptions);
                // Check and throw if there are any errors with the transfer operation.
                transferOperationResult.Check();
                // Remove files that have been downloaded.
                foreach (TransferEventArgs transfer in transferOperationResult.Transfers)
                {
                    RemovalOperationResult removalResult = session.RemoveFiles(session.EscapeFileMask(transfer.FileName));
 
                    if (!removalResult.IsSuccess)
                    {
                        eventLogUtility.WriteToEventLog("There was an error removing the file: " + transfer.FileName + " from " + sessionOptions.HostName + ".", EventLogEntryType.Error);
                    }
                }
            }
        }
    }
