    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.IO;
    
    namespace GetImageA
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("your image uri");
                GetImage(uri);
            }
            public static void GetImage(Uri uri)
            {
                    var username = "username";
                    var password = "password";
    
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(
                                ASCIIEncoding.ASCII.GetBytes(
                                    string.Format("{0}:{1}", username, password))));
                        Stream str = client.GetStreamAsync(uri).Result;
                        Image im = Image.FromStream(str);
                        im.Save("E:\\image.png");
                    }
            }
        }
    }
