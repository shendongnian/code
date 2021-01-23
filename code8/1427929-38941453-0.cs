    using (var sw = System.IO.File.Create(csvPath))
                {
                    var preamble = Encoding.UTF8.GetPreamble();
                    sw.Write(preamble, 0, preamble.Length);
                    var databytes = Encoding.UTF8.GetBytes(data);
                    sw.Write(databytes, 0, data.Length);
                }
