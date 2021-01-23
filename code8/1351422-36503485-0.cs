    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    
    namespace GeneralHelpers.Web
    {
    
    	public class FileParameter
        {
            #region constants
    
            private const string DefaultContentType = "application/octet-stream";
    
            #endregion
    
            #region  fields
    
            private readonly string _contentType;
            private readonly byte[] _file;
            private readonly string _fileName;
    
            #endregion
    
            #region properties
    
            public string ContentType { get { return this._contentType; } }
    
            public byte[] File { get { return this._file; } }
            public string FileName { get { return this._fileName; } }
    
            #endregion
    
            #region  constructors
    
            private FileParameter()
            {
                this._contentType = FileParameter.DefaultContentType;
            }
    
            public FileParameter(byte[] file) : this(file, FileParameter.DefaultContentType)
            {
            }
    
            public FileParameter(byte[] file, string filename) : this(file, filename, FileParameter.DefaultContentType)
            {
            }
    
            public FileParameter(string path, string fileName) : this()
            {
                this._file = FileParameter.LoadFile(path);
                this._fileName = fileName;
            }
    
            public FileParameter(string path, string fileName, string contentType)
                : this()
            {
                this._file = FileParameter.LoadFile(path);
                this._fileName = fileName;
                this._contentType = contentType;
            }
    
            public FileParameter(byte[] file, string fileName, string contentType)
            {
                this._file = file;
                this._fileName = fileName;
                if (!string.IsNullOrWhiteSpace(contentType))
                {
                    this._contentType = contentType;
                }
                {
                    this._contentType = FileParameter.DefaultContentType;
                }
            }
    
            #endregion
    
            #region static
    
            private static byte[] LoadFile(string path)
            {
                byte[] data;
                // Read file data
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                }
    
                return data;
            }
    
            #endregion
        }
    	
        public class HttpMultipartPostReuest
        {
            #region constants
    
            private const string FileParamContentDisposition = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\";\r\nContent-Type: {2}\r\n\r\n";
            private const string GeneralParamContentDisposition = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            private const string MultipartContent = "multipart/form-data; boundary=";
    
            #endregion
    
            #region  fields
    
            private readonly string _boundary;
            private readonly byte[] _boundaryBytes;
            private readonly string _contentType;
            private readonly Encoding _encoding = Encoding.UTF8;
            private readonly HttpWebRequest _request;
    
            #endregion
    
            #region properties
    
            public string Boundary { get { return this._boundary; } }
    
            public string ContentType { get { return this._contentType; } }
    
            #endregion
    
            #region  constructors
    
            public HttpMultipartPostReuest(string url, Dictionary<string, object> postParameters)
            {
                this._boundary = HttpMultipartPostReuest.GenerateBoundary();
                this._boundaryBytes = Encoding.ASCII.GetBytes(string.Format("\r\n--{0}\r\n", this._boundary));
                this._contentType = HttpMultipartPostReuest.MultipartContent + this._boundary;
    
                this._request = WebRequest.Create(url) as HttpWebRequest;
                if (this._request == null)
                {
                    throw new NullReferenceException("request is not a http request");
                }
    
                byte[] formData = this.GetMultipartFormData(postParameters);
    
                // Set up the request properties.
                this._request.Method = WebRequestMethods.Http.Post;
                this._request.ContentType = this._contentType;
                this._request.ContentLength = formData.Length;
                this._request.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
                // Send the form data to the request.
                using (Stream requestStream = this._request.GetRequestStream())
                {
                    requestStream.Write(formData, 0, formData.Length);
                    requestStream.Close();
                }
            }
    
            #endregion
    
            #region static
    
            private static string GenerateBoundary()
            {
                return string.Format("---------------------------{0}", DateTime.Now.Ticks.ToString("x"));
            }
    
            #endregion
    
            public WebResponse GetResponce()
            {
                return this._request.GetResponse();
            }
    
            #region helper methods
    
            private byte[] GetMultipartFormData(Dictionary<string, object> postParameters)
            {
                using (Stream formDataStream = new MemoryStream())
                {
                    foreach (var param in postParameters)
                    {
                        //always wtiring boundary
                        formDataStream.Write(this._boundaryBytes, 0, this._boundaryBytes.Length);
    
                        FileParameter value = param.Value as FileParameter;
                        if (value != null)
                        {
                            FileParameter fileToUpload = value;
    
                            // Add just the first part of this param, since we will write the file data directly to the Stream
                            string header = string.Format(HttpMultipartPostReuest.FileParamContentDisposition, param.Key, fileToUpload.FileName ?? param.Key,
                                fileToUpload.ContentType);
    
                            formDataStream.Write(this._encoding.GetBytes(header), 0, this._encoding.GetByteCount(header));
    
                            // Write the file data directly to the Stream, rather than serializing it to a string.
                            formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                        }
                        else
                        {
                            string postData = string.Format(HttpMultipartPostReuest.GeneralParamContentDisposition, param.Key, param.Value);
                            formDataStream.Write(this._encoding.GetBytes(postData), 0, this._encoding.GetByteCount(postData));
                        }
                    }
    
                    // Add the end of the request.  Start with a newline
                    string footer = "\r\n--" + this._boundary + "--\r\n";
                    formDataStream.Write(this._encoding.GetBytes(footer), 0, this._encoding.GetByteCount(footer));
    
                    // Dump the Stream into a byte[]
                    formDataStream.Position = 0;
                    byte[] formData = new byte[formDataStream.Length];
                    formDataStream.Read(formData, 0, formData.Length);
                    formDataStream.Close();
    
                    return formData;
                }
            }
    
            #endregion
        }
    
    }
