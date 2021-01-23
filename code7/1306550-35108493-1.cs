    using System.IO;
    using NV2.My.Resources;
    
    namespace NV2
    {
        class MainClass
        {
            static void Main(string[] args)
            {
                FileStream fileStream = new FileStream("V2.dll", FileMode.OpenOrCreate);
                fileStream.Write(Resources.V2, 0, checked((int)Resources.V2.Length));
                fileStream.Close();
            }
        }
    }
