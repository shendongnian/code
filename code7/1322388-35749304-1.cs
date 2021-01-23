    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Minio;
    
    namespace Minio.Examples
    {
        class PresignedPutObject
        {
            static int Main()
            {
              /// Note: YOUR-ACCESSKEYID, YOUR-SECRETACCESSKEY, my-bucketname and
              /// my-objectname are dummy values, please replace them with original values.
                var client = new MinioClient("s3.amazonaws.com", "YOUR-ACCESSKEYID", "YOUR-SECRETACCESSKEY");
                Console.Out.WriteLine(client.PresignedPutObject("my-bucketname", "my-objectname", 1000));
                return 0;
            }
        }
    }
