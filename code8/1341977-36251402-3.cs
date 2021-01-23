    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ReleaseManager.Interfaces;
    using Renci.SshNet;
    using Renci.SshNet.Common;
    using Renci.SshNet.Sftp;
    using System.Text;
    using System.IO;
    
    namespace ReleaseManager.BusinessObjects
    {
        public class SFTPDirectory : IDirectory
        {
            public SftpClient client;
            public RemoteInfo Info;
    
            public SFTPDirectory()
            {
                this.Info = new RemoteInfo();
                this.Info.DirInfo = new List<RemoteDirInfo>();
                this.Info.FileInfo = new List<RemoteFileInfo>();
                this.Info.Error = "";
            }
    
            public void Connect(string Host, int Port, string Username, string Password, string Fingerprint)
            {
                int sftpPort = 22;      // default sftp port
    
                if (Port != 0)
                    sftpPort = Port;
    
                ConnectionInfo connInfo = new ConnectionInfo(Host, sftpPort, Username, new AuthenticationMethod[]{
                        new PasswordAuthenticationMethod(Username, Password)
                    });
    
                this.client = new SftpClient(connInfo);
                this.client.HostKeyReceived += delegate(object sender, HostKeyEventArgs e)
                {
                    if (Fingerprint.ToLower() == (e.HostKeyName + " " + e.KeyLength + " " + BitConverter.ToString(e.FingerPrint).Replace("-", ":")).ToLower())
                        e.CanTrust = true;
                    else
                        e.CanTrust = false;
                };
    
                this.client.Connect();
            }
    
            public string GetWorkingDirectory(string Directory)
            {
                return Directory;
            }
    
            public void ListDirectory(string Directory)
            {
                List<SftpFile> files = this.client.ListDirectory(Directory).ToList();
    
                foreach (var file in files)
                {
                    if (file.IsDirectory)
                    {
                        if (file.Name != "." && file.Name != "..")
                            this.Info.DirInfo.Add(new RemoteDirInfo
                            {
                                Name = file.Name,
                                ModifiedDate = file.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss")
                            });
                    }
                    else
                    {
                        this.Info.FileInfo.Add(new RemoteFileInfo
                        {
                            Name = file.Name,
                            ModifiedDate = file.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"),
                            Size = file.Length
                        });
                    }
                }
            }
    
            public void CreateDirectory(string Directory)
            {
                this.client.CreateDirectory(Directory);
            }
    
            public void DeleteDirectory(string Directory)
            {
                this.client.DeleteDirectory(Directory);
            }
    
            public void CopyFile(string srcFile, string dstFile)
            {
                using (var uplfileStream = System.IO.File.OpenRead(srcFile))
                {
                    this.client.UploadFile(uplfileStream, dstFile.Replace("\\", "/"), true);
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
                {
                    this.client.UploadFile(stream, Filename.Replace("\\", "/"), true);
                }
            }
    
            public Boolean DirectoryExists(string Directory)
            {
                return this.client.Exists(Directory);
            }
    
            public void Disconnect()
            {
                this.client.Disconnect();
            }
        }
    }
