    public class VO_eLoyalty : IVO_Upload
    {
    
                    string IVO_Upload.UploadFile(RemoteFileInfo request)
                    {
                                    string _uploadFolder = "PATH_TO_SAVE_FILE";
                                    string filePath = Path.Combine(_uploadFolder, request.FileName);
                                    using (targetStream = new FileStream(filePath, FileMode.Create,
                                    FileAccess.Write, FileShare.None))
                                    {
                                                    //read from the input stream in 65000 byte chunks
    
                                                    const int bufferLen = 65000;
                                                    byte[] buffer = new byte[bufferLen];
                                                    int count = 0;
                                                    while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                                                    {
                                                                    // save to output stream
                                                                    targetStream.Write(buffer, 0, count);
                                                    }
                                                    
                                                    targetStream.Close();
                                                    sourceStream.Close();
    
                                    }
                                    return "details"; // return whatever you need to here, or change the return type to whatever you need
    
                    }
    }
