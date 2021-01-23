    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Minio;
    
    namespace Minio.Examples
    {
        class PresignedPostPolicy
        {
            static int Main()
            {
              /// Note: YOUR-ACCESSKEYID, YOUR-SECRETACCESSKEY, my-bucketname and
              /// my-objectname are dummy values, please replace them with original values.
                var client = new MinioClient("s3.amazonaws.com", "YOUR-ACCESSKEYID", "YOUR-SECRETACCESSKEY");
                PostPolicy form = new PostPolicy();
                DateTime expiration = DateTime.UtcNow;
                form.SetExpires(expiration.AddDays(10));
                form.SetKey("my-objectname");
                form.SetBucket("my-bucketname");
    
                Dictionary <string, string> formData = client.PresignedPostPolicy(form);
                string curlCommand = "curl ";
                foreach (KeyValuePair<string, string> pair in formData)
                {
                        curlCommand = curlCommand + " -F " + pair.Key + "=" + pair.Value;
                }
                curlCommand = curlCommand + " -F file=@/etc/bashrc https://s3.amazonaws.com/my-bucketname";
                Console.Out.WriteLine(curlCommand);
                return 0;
            }
        }
    }
