      using (Stream fs = File.Open(@"C:\Users\Mohamed\Desktop\Hany.jpg", FileMode.Open))
            {
                StreamWriter OutputStream = new StreamWriter(new BufferedStream(someSocket.GetStream()));
                OutputStream.WriteLine("HTTP/1.0 200 OK");
                OutputStream.WriteLine("Content-Type: application/octet-stream");
                OutputStream.WriteLine("Content-Disposition: attachment; filename=Hany.jpg");
                OutputStream.WriteLine("Content-Length: " + img.Length);
                OutputStream.WriteLine("Connection: close");
                OutputStream.WriteLine(""); // this terminates the HTTP headers
                OutputStream.Flush();
                fs.CopyTo(OutputStream.BaseStream);
                OutputStream.BaseStream.Flush();
                OutputStream.Flush();
            }
