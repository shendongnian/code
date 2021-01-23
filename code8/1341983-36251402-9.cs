    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ReleaseManager.Interfaces;
    using System.Net;
    using System.Text;
    using System.IO;
    
    
    namespace ReleaseManager.BusinessObjects
    {
        public class LocalDirectory : IDirectory
        {
            public RemoteInfo Info;
    
            public LocalDirectory()
            {
                this.Info = new RemoteInfo();
                this.Info.DirInfo = new List<RemoteDirInfo>();
                this.Info.FileInfo = new List<RemoteFileInfo>();
                this.Info.Error = "";
            }
    
            public void Connect(string Host, int Port, string Username, string Password, string Fingerprint)
            {
            }
    
            public string GetWorkingDirectory(string Directory)
            {
                return Directory;
            }
    
            public void ListDirectory(string Directory)
            {
                DirectoryInfo di = new DirectoryInfo(Directory);
    
                foreach (var item in di.EnumerateDirectories("*"))
                {
                    if (item.Name != "." && item.Name != "..")
                        this.Info.DirInfo.Add(new RemoteDirInfo
                        {
                            Name = item.Name,
                            ModifiedDate = item.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss")
                        });
                }
    
                foreach (var item in di.EnumerateFiles("*"))
                {
                    this.Info.FileInfo.Add(new RemoteFileInfo
                    {
                        Name = item.Name,
                        ModifiedDate = item.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"),
                        Size = item.Length
                    });
                }
            }
    
            public void CreateDirectory(string Directory)
            {
                System.IO.Directory.CreateDirectory(Directory);
            }
    
            public void DeleteDirectory(string Directory)
            {
                System.IO.Directory.Delete(Directory, true);
            }
    
            public void CopyFile(string srcFile, string dstFile)
            {
                System.IO.File.Copy(srcFile, dstFile);
            }
    
            public void WriteAllText(string Filename, string Content, Encoding enc = null)
            {
                if (enc == null)
                    System.IO.File.WriteAllText(Filename, Content);
                else
                    System.IO.File.WriteAllText(Filename, Content, enc);
            }
    
            public Boolean DirectoryExists(string Directory)
            {
                return System.IO.Directory.Exists(Directory);
            }
    
            public void Disconnect()
            {
            }
        }
    
    }
