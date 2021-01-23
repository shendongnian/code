            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var gridFsInfo = DB.GridFS.Upload(fs, fileName);
                var fileId = gridFsInfo.Id;
                ObjectId oid = new ObjectId(fileId.ToString());
                var file = DB.GridFS.FindOne(Query.EQ("_id", oid));
                using (var stream = file.OpenRead())
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    using (var newFs = new FileStream(newFileName, FileMode.Create))
                    {
                        newFs.Write(bytes, 0, bytes.Length);
                        Image image = Image.FromStream(newFs);
                        f2.SizeMode = PictureBoxSizeMode.StretchImage;
                        f2.Image = image;
                    }
                }
            }
