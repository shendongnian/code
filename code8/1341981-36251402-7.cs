    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ReleaseManager.Interfaces;
    using System.Net.FtpClient;
    using System.Net;
    using System.Text;
    using System.IO;
    
    
    namespace ReleaseManager.BusinessObjects
    {
        public class FTPDirectory : IDirectory
        {
            private FtpClient client;
            public RemoteInfo Info;
    
            public FTPDirectory()
            {
                this.client = new FtpClient();
    
                this.Info = new RemoteInfo();
                this.Info.DirInfo = new List<RemoteDirInfo>();
                this.Info.FileInfo = new List<RemoteFileInfo>();
                this.Info.Error = "";
            }
    
            public void Connect(string Host, int Port, string Username, string Password, string Fingerprint)
            {
                int ftpPort = 21;      // default ftp port
    
                if (Port != 0)
                    ftpPort = Port;
    
                this.client.Host = Host;
                this.client.Port = ftpPort;
                this.client.Credentials = new NetworkCredential(Username, Password);
            }
    
            public string GetWorkingDirectory(string Directory)
            {
                this.client.SetWorkingDirectory(Directory);
    
                return this.client.GetWorkingDirectory();
            }
    
            public void ListDirectory(string Directory)
            {
                this.client.SetWorkingDirectory(Directory);
    
                foreach (var item in this.client.GetListing(this.client.GetWorkingDirectory()))
                {
                    switch (item.Type)
                    {
                        case FtpFileSystemObjectType.Directory:
                            if (item.Name != "." && item.Name != "..")
                                this.Info.DirInfo.Add(new RemoteDirInfo
                                {
                                    Name = item.Name,
                                    ModifiedDate = item.Modified.ToString("yyyy/MM/dd HH:mm:ss")
                                });
    
                            break;
    
                        case FtpFileSystemObjectType.File:
                            this.Info.FileInfo.Add(new RemoteFileInfo
                            {
                                Name = item.Name,
                                ModifiedDate = item.Modified.ToString("yyyy/MM/dd HH:mm:ss"),
                                Size = item.Size
                            });
    
                            break;
                    }
                }
            }
    
            public void CreateDirectory(string Directory)
            {
                this.client.CreateDirectory(Directory);
            }
    
            public void DeleteDirectory(string Directory)
            {
                this.client.DeleteDirectory(Directory, true, FtpListOption.Recursive);
            }
    
            public void CopyFile(string srcFile, string dstFile)
            {
                using (var fileStream = System.IO.File.OpenRead(srcFile))
                using (var ftpStream = this.client.OpenWrite(dstFile.Replace("\\", "/")))
                {
                    var buffer = new byte[8 * 1024];
                    int count;
    
                    while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, count);
                    }
                }
            }
    
            public void WriteAllText(string Filename, string Content, Encoding enc = null)
            {
                byte[] byteArray;
    
                if (enc == null)
                    byteArray = Encoding.ASCII.GetBytes(Content);
                else
                    byteArray = enc.GetBytes(Content);
    
                using (MemoryStream stream = new MemoryStream(byteArray))
                using (var ftpStream = this.client.OpenWrite(Filename.Replace("\\", "/")))
                {
                    var buffer = new byte[8 * 1024];
                    int count;
    
                    while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, count);
                    }
                }
            }
    
            public Boolean DirectoryExists(string Directory)
            {
                return this.client.DirectoryExists(Directory);
            }
    
            public void Disconnect()
            {
                this.client.Disconnect();
            }
        }
    
    }
