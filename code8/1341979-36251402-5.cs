    using System;
    using System.Text;
    
    namespace ReleaseManager.Interfaces
    {
        interface IDirectory
        {
            void Connect(string Host, int Port, string Username, string Password, string Fingerprint);
            string GetWorkingDirectory(string Directory);
            void ListDirectory(string Directory);
            void CreateDirectory(string Directory);
            void DeleteDirectory(string Directory);
            Boolean DirectoryExists(string Directory);
            void WriteAllText(string FileName, string Content, Encoding enc);
            void CopyFile(string srcFile, string dstFile);
            void Disconnect();
        }
    
    }
