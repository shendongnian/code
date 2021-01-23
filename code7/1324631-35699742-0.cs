    using System;
    using System.Text;
    namespace Demo
    {
        internal static class AppSettings
        {
            static AppSettings()
            {
                FileEncodingText = "UTF8";
                Console.WriteLine("AppSettings - Static constructor called.");
            }
            private static string _fileEncodingText = "UTF8";
            public static string FileEncodingText
            {
                get { return _fileEncodingText; }
                set
                {
                    string oldValue = _fileEncodingText;
                    _fileEncodingText = value;
                    try
                    {
                        FileEncoding = Encoding.GetEncoding(value);
                    }
                    catch (System.Exception)
                    {
                        _fileEncodingText = oldValue;
                        FileEncoding = Encoding.UTF8;
                    }
                }
            }
            public static Encoding FileEncoding { get; private set; }
        }
        class Program
        {
            static void Main()
            {
                Console.WriteLine(AppSettings.FileEncodingText);
            }
        }
    }
