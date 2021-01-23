    using System;
    using System.Linq;
    using System.Web;
    using Telerik.Web.UI.PersistenceFramework;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
     
    public class CookieStorageProvider : IStateStorageProvider
    {
        private static readonly Encoding AsciiEncoding = System.Text.Encoding.ASCII;
        private static readonly int MaxCookieSize = 4000;
        private static readonly int LengthDataByteCount = sizeof(Int32);
        private string StorageKey { get; set; }
     
        #region IStateStorageProvider
     
        public CookieStorageProvider(string key)
        {
            StorageKey = key;
        }
     
        public void SaveStateToStorage(string key, string serializedState)
        {
            HttpCookie cookie = new HttpCookie(StorageKey);
            string settingsData = CompressString(serializedState);
     
            if (settingsData.Length > MaxCookieSize)
            {
                throw new ArgumentOutOfRangeException("Current settings exceed 4k in compressed form! Operation canceled!");
            }
     
            cookie.Value = settingsData;
     
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
     
        public string LoadStateFromStorage(string key)
        {
            return DecompressString(HttpContext.Current.Request.Cookies[StorageKey].Value.ToString());
        }
     
        #endregion
     
        private string CompressString(string inputString)
        {
            byte[] outputBytes = null;
            byte[] inputBytes = AsciiEncoding.GetBytes(inputString);
     
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress))
                {
                    zipStream.Write(inputBytes, 0, inputBytes.Length);
                }
                outputBytes = ms.ToArray();
            }
     
            return Convert.ToBase64String(AddDataCount(outputBytes, inputBytes.Length));
        }
     
        private string DecompressString(string inputString)
        {
            string outputString = String.Empty;
            byte[] inputBytes = Convert.FromBase64String(inputString);
            Int32 lengthDataArray = BitConverter.ToInt32(inputBytes, inputBytes.Length - LengthDataByteCount);
            byte[] outputBytes = new byte[lengthDataArray];
     
            using (MemoryStream ms = new MemoryStream(RemoveDataCount(inputBytes)))
            {
                using (GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zipStream.Read(outputBytes, 0, outputBytes.Length);
                }
                outputString = AsciiEncoding.GetString(outputBytes);
            }
     
            return outputString;
        }
     
        private byte[] AddDataCount(byte[] inputArray, Int32 length)
        {
            byte[] lengthDataArray = BitConverter.GetBytes(length);
            Array.Resize<byte>(ref inputArray, inputArray.Length + LengthDataByteCount);
            Array.Copy(lengthDataArray, 0, inputArray, inputArray.Length - LengthDataByteCount, LengthDataByteCount);
            return inputArray;
        }
     
        private byte[] RemoveDataCount(byte[] inputArray)
        {
            Array.Resize<byte>(ref inputArray, inputArray.Length - LengthDataByteCount);
            return inputArray;
        }
    }
