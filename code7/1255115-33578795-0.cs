    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Minio;
    using Minio.Xml;
    
    namespace Minio.Examples
    {
        class ListObjects
        {
            static int Main(string[] args)
            {
                var client = new MinioClient("https://s3.amazonaws.com", "ACCESSKEY", "SECRETKEY");
    
                var items = client.ListObjects("bucket");
    
                foreach (Item item in items)
                {
                    if (item.IsDir)
                    {
                        Console.Out.WriteLine("{0}", item.Key);
                    }
                }
                return 0;
            }
        }
    }
