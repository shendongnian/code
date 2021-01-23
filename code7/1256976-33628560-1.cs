    using UnityEngine;
    using System.Collections;
    using System.IO;
    using System;
    using System.Net;
    
    //////////////////////////////////////////////////////////////////////////
    //CLASS
    //////////////////////////////////////////////////////////////////////////
    public class FTPUpload : MonoBehaviour
    {    
    	#region Methods
    	//////////////////////////////////////////////////////////////////////////
    	//METHODS
    	//////////////////////////////////////////////////////////////////////////
        public void CallThisWithButton()
        {
            Upload("PATH_TO_YOUR_FILE", "YOUR_FTP_SERVER_ADRESS", "YOUR_USERNAME", "YOUR_PASSWORD", "ANY_SUB_FOLDER");
        }
    
        /// <summary>
        /// Uploads a file through FTP.
        /// </summary>
        /// <param name="filename">The path to the file to upload.</param>
        /// <param name="server">The server to use.</param>
        /// <param name="username">The username to use.</param>
        /// <param name="password">The password to use.</param>
        /// <param name="initialPath">The path on the server to upload to.</param>
        static void Upload(string filename, string server, string username, string password, string initialPath)
        {
            Debug.Log("Upload started.");
    
            var file = new FileInfo(filename);
            var address = new Uri("ftp://" + server + "/" + Path.Combine(initialPath, file.Name));
            var request = FtpWebRequest.Create(address) as FtpWebRequest;
    
            // Upload options:
    
            // Provide credentials
            request.Credentials = new NetworkCredential(username, password);
    
            // Set control connection to closed after command execution
            request.KeepAlive = false;
    
            // Specify command to be executed
            request.Method = WebRequestMethods.Ftp.UploadFile;
    
            // Specify data transfer type
            request.UseBinary = true;
    
            // Notify server about size of uploaded file
            request.ContentLength = file.Length;
    
            // Set buffer size to 2KB.
            var bufferLength = 2048;
            var buffer = new byte[bufferLength];
            var contentLength = 0;
    
            // Open file stream to read file
            var fs = file.OpenRead();
    
            try
            {
                // Stream to which file to be uploaded is written.
                var stream = request.GetRequestStream();
    
                // Read from file stream 2KB at a time.
                contentLength = fs.Read(buffer, 0, bufferLength);
    
                // Loop until stream content ends.
                while (contentLength != 0)
                {
                    //Debug.Log("Progress: " + ((fs.Position / fs.Length) * 100f));
                    // Write content from file stream to FTP upload stream.
                    stream.Write(buffer, 0, contentLength);
                    contentLength = fs.Read(buffer, 0, bufferLength);
                }
    
                // Close file and request streams
                stream.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Debug.LogError("Error uploading file: " + e.Message);
                return;
            }
    
            Debug.Log("Upload successful.");
        }
    	//////////////////////////////////////////////////////////////////////////
    	#endregion
    }
    //////////////////////////////////////////////////////////////////////////
