    using OsmSharp.Geo;
    using OsmSharp.Osm.PBF.Streams;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    namespace Sample.GeometryStream
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test();
                Console.ReadLine();
    
            }
            static async Task Test()
            {
    
                await ToFile("http://files.itinero.tech/data/OSM/planet/europe/luxembourg-latest.osm.pbf", "test.pbf");
    
                var sr = new StreamReader("test.pbf");
                using (var ms = new MemoryStream())
                {
                    try
                    {
                        sr.BaseStream.CopyTo(ms);
                    }
                    catch
                    {
                        //TODO: Handle exceptions
                    }
                    finally
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                    var pbfStreamSource = new PBFOsmStreamSource(ms);
                }
            }
            
            public static async Task ToFile(string url, string filename)
            {
                if (!File.Exists(filename))
                {
                    var client = new HttpClient();
                    using (var stream = await client.GetStreamAsync(url))
                    using (var outputStream = File.OpenWrite(filename))
                    {
                        stream.CopyTo(outputStream);
                    }
                }
            }
    
        }
    }
