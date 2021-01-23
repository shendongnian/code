    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    
    namespace Copy_From_FTP
    {
        class Program
        {
            
            public static void Main(string[] args)
            {
                List<FileName> sourceFileList = new List<FileName>();
                List<FileName> targetFileList = new List<FileName>();
    
                //string targetURI = ftp://www.target.com
                //string targetUser = userName
                //string targetPass = passWord
                //string sourceURI = ftp://www.source.com
                //string sourceUser = userName
                //string sourcePass = passWord
    
                getFileLists(sourceURI, sourceUser, sourcePass, sourceFileList, targetURI, targetUser, targetPass, targetFileList);
    
                Console.WriteLine(sourceFileList.Count + " files found!");
    
                CheckLists(sourceFileList, targetFileList);
    			targetFileList.Sort();
    
                Console.WriteLine(sourceFileList.Count + " unique files on sourceURI"+Environment.NewLine+"Attempting to move them.");
    
                foreach(var file in sourceFileList)
                {
                    try
                    {
                        CopyFile(file.fName, sourceURI, sourceUser, sourcePass, targetURI, targetUser, targetPass);
                    }
                    catch
                    {
                        Console.WriteLine("There was move error with : "+file.fName);
                    }                    
                }            
            }
    
            public class FileName : IComparable<FileName>
            {
                public string fName { get; set; }
                public int CompareTo(FileName other)
                {
                    return fName.CompareTo(other.fName);
                }
            }
    
            public static void CheckLists(List<FileName> sourceFileList, List<FileName> targetFileList)
            {
                for (int i = 0; i < sourceFileList.Count;i++ )
                {
                    if (targetFileList.BinarySearch(sourceFileList[i]) > 0)
                    {
                        sourceFileList.RemoveAt(i);
                        i--;
                    }
                }
            }
    
            public static void getFileLists(string sourceURI, string sourceUser, string sourcePass, List<FileName> sourceFileList,string targetURI, string targetUser, string targetPass, List<FileName> targetFileList)
            {
                string line = "";
                /////////Source FileList
                FtpWebRequest sourceRequest;
                sourceRequest = (FtpWebRequest)WebRequest.Create(sourceURI);
                sourceRequest.Credentials = new NetworkCredential(sourceUser, sourcePass);
                sourceRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                sourceRequest.UseBinary = true;
                sourceRequest.KeepAlive = false;
                sourceRequest.Timeout = -1;
                sourceRequest.UsePassive = true;
                FtpWebResponse sourceRespone = (FtpWebResponse)sourceRequest.GetResponse();
                //Creates a list(fileList) of the file names
                using (Stream responseStream = sourceRespone.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            var fileName = new FileName
    						{
    							fName = line
    						};
    						sourceFileList.Add(fileName);
                            line = reader.ReadLine();
                        }
                    }
                }
                /////////////Target FileList
                FtpWebRequest targetRequest;
                targetRequest = (FtpWebRequest)WebRequest.Create(targetURI);
                targetRequest.Credentials = new NetworkCredential(targetUser, targetPass);
                targetRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                targetRequest.UseBinary = true;
                targetRequest.KeepAlive = false;
                targetRequest.Timeout = -1;
                targetRequest.UsePassive = true;
                FtpWebResponse targetResponse = (FtpWebResponse)targetRequest.GetResponse();
                //Creates a list(fileList) of the file names
                using (Stream responseStream = targetResponse.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        line = reader.ReadLine();
                        while (line != null)
                        {
                            var fileName = new FileName
    						{
    							fName = line
    						};
    						targetFileList.Add(fileName);
                            line = reader.ReadLine();
                        }
                    }
                }
            }
    
            public static void CopyFile(string fileName, string sourceURI, string sourceUser, string sourcePass,string targetURI, string targetUser, string targetPass )
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(sourceURI + fileName);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(sourceUser, sourcePass);
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    Upload(fileName, ToByteArray(responseStream),targetURI,targetUser, targetPass);
                    responseStream.Close();
                }
                catch
                {
                    Console.WriteLine("There was an error with :" + fileName);
                }
            }
    
            public static Byte[] ToByteArray(Stream stream)
            {
                MemoryStream ms = new MemoryStream();
                byte[] chunk = new byte[4096];
                int bytesRead;
                while ((bytesRead = stream.Read(chunk, 0, chunk.Length)) > 0)
                {
                    ms.Write(chunk, 0, bytesRead);
                }
    
                return ms.ToArray();
            }
    
            public static bool Upload(string FileName, byte[] Image, string targetURI,string targetUser, string targetPass)
            {
                try
                {
                    FtpWebRequest clsRequest = (FtpWebRequest)WebRequest.Create(targetURI+FileName);
                    clsRequest.Credentials = new NetworkCredential(targetUser, targetPass);
                    clsRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    Stream clsStream = clsRequest.GetRequestStream();
                    clsStream.Write(Image, 0, Image.Length);
                    clsStream.Close();
                    clsStream.Dispose();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
