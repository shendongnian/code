            using (var stream = System.IO.File.AppendText(Server.MapPath("~/App_Data/data.txt")))
            {
                stream.WriteLine("testing..");
                stream.Flush();
            }
