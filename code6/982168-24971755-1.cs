    using System;
    using System.Drawing.Imaging;
    using System.Drawing;
    using System.Text;
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Add reference => Assemblies => Framework => System.Drawing
                // Set the path to your photo file.
                var path = @"[Path to your image]";
                // Create image object
                var image = new Bitmap(path);
                // Get PropertyItems
                var propItems = image.PropertyItems;
                // Remove encoding object
                var encodings = new ASCIIEncoding();
                // Display 
                foreach (var propItem in propItems)
                {
                    // The values below come from http://msdn.microsoft.com/en-us/library/xddt0dz7(v=vs.110).aspx
                    // Find al values available with Console.WriteLine(propItem.Id.ToString("x"));
                    if (propItem.Id.ToString("x").Equals("110")) //Equipment model
                    {
                        var model = encodings.GetString(propItem.Value);
                        Console.WriteLine("Model:\t" + model);
                    }
                    if (propItem.Id.ToString("x").Equals("9003")) //ExifDTOriginal
                    {
                        var datetime = encodings.GetString(propItem.Value);
                        Console.WriteLine("Taken:\t" + datetime);
                    }
                }
                Console.Read();
            }
        }
    }
        // =>
        //    Model:  FinePix S9500
        //    Taken:  2012:11:30 13:58:04
