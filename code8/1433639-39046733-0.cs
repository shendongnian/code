    using UnityEngine;
    using System.Collections;
    using System;
    using System.Net;
    using System.IO;
    
    public class Uploader : MonoBehaviour
    {
        public string FTPHost = "ftp://byethost7.com";
        public string FTPUserName = "b7_18750253";
        public string FTPPassword = "xxx";
        public string FilePath;
    
        public void UploadFile()
        {
            FilePath = Application.dataPath + "/StreamingAssets/data.xml";
            Debug.Log("Path: " + FilePath);
    
    
            WebClient client = new System.Net.WebClient();
            Uri uri = new Uri(FTPHost + new FileInfo(FilePath).Name);
    
            client.UploadProgressChanged += new UploadProgressChangedEventHandler(OnFileUploadProgressChanged);
            client.UploadFileCompleted += new UploadFileCompletedEventHandler(OnFileUploadCompleted);
            client.Credentials = new System.Net.NetworkCredential(FTPUserName, FTPPassword);
            client.UploadFileAsync(uri, "STOR", FilePath);
        }
    
        void OnFileUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            Debug.Log("Uploading Progreess: " + e.ProgressPercentage);
        }
    
        void OnFileUploadCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            Debug.Log("File Uploaded");
        }
    
        void Start()
        {
            UploadFile();
        }
    }
