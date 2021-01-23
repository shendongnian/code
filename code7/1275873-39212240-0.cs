    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Renci.SshNet;
    using Renci.SshNet.Sftp;
    using System.IO;
    using System.Configuration;
    using System.IO.Compression;
    
    public class RemoteFileOperations
    {
        private string ftpPathSrcFolder = "/Path/Source/";//path should end with /
        private string ftpPathDestFolder = "/Path/Archive/";//path should end with /
        private string ftpServerIP = "Target IP";
        private int ftpPortNumber = 80;//change to appropriate port number
        private string ftpUserID = "FTP USer Name";//
        private string ftpPassword = "FTP Password";
        /// <summary>
        /// Moves contents of one remote Folder to another
        /// </summary>
        public void MoveFolderToArchive()
    	{
    		using (SftpClient sftp = new SftpClient(ftpServerIP, ftpPortNumber, ftpUserID, ftpPassword))
    		{
    			SftpFile eachRemoteFile = sftp.ListDirectory(ftpPathSrcFolder).First();//Get first file in the Directory			
    			if(eachRemoteFile.IsRegularFile)//Move only file
    			{
    				bool eachFileExistsInArchive = CheckIfRemoteFileExists(sftp, ftpPathDestFolder, eachRemoteFile.Name);
    
    				//MoveTo will result in error if filename alredy exists in the target folder. Prevent that error by cheking if File name exists
    				string eachFileNameInArchive = eachRemoteFile.Name;
    
    				if (eachFileExistsInArchive)
    				{
    					eachFileNameInArchive = eachFileNameInArchive + "_" + DateTime.Now.ToString("MMddyyyy_HHmmss");//Change file name if the file already exists
    				}
    				eachRemoteFile.MoveTo(ftpPathDestFolder + eachFileNameInArchive);
    			}			
    		}
    	}
    
        /// <summary>
        /// Checks if Remote folder contains the given file name
        /// </summary>
        public bool CheckIfRemoteFileExists(SftpClient sftpClient, string remoteFolderName, string remotefileName)
        {
            bool isFileExists = sftpClient
                                .ListDirectory(remoteFolderName)
                                .Any(
                                        f => f.IsRegularFile &&
                                        f.Name.ToLower() == remotefileName.ToLower()
                                    );
            return isFileExists;
        }
    
    }
