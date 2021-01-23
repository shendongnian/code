    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var f = @"\D:\temp\test.xls";
            p.Dos2Unix(f);
        }
        private void Dos2Unix(string fileName)
        {
           const byte CR = 0x0D;
           const byte LF = 0x0A;
           byte[] data = File.ReadAllBytes(fileName);
           using (FileStream fileStream = File.OpenWrite(fileName))
           {
               BinaryWriter bw = new BinaryWriter(fileStream);
               int position = 0;
               int index = 0;
               do
               {
                 index = Array.IndexOf<byte>(data, CR, position);
                 if ((index >= 0) && (data[index + 1] == LF))
                 {
                   // Write before the CR
                   bw.Write(data, position, index - position);
                   // from LF
                   position = index + 1;
                 }
               }
                    while (index > 0);
                    bw.Write(data, position, data.Length - position);
                    fileStream.SetLength(fileStream.Position);
                }
        }
     }
    }
