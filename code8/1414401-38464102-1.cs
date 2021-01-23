    var filename = "yourfile.sql";
    var outcount = 0;
    var filecounter = 0;
    var outfileformatter = Path.GetFileNameWithoutExtension(filename) + "_{0}" +
                           Path.GetExtension(filename);
    string outfile = null;
    StreamWriter writer = null;
    var blocksize = 32*1024;
    var block = new char[blocksize];
    using (var reader = new StreamReader(filename))
    {
        while (!reader.EndOfStream)
        {
            var outsize = reader.ReadBlock(block, 0, blocksize);
            var content = new string(block, 0, outsize);
            var chunks = content.Split(new[] { "INSERT INTO" }, StringSplitOptions.None)
                                .Select(c => string.Format("INSERT INTO{0}", c));
            foreach (var chunk in chunks)
            {
                if (outcount > 48 * 1024 * 1024 || outfile == null) //48MB
                {
                    filecounter++;
                    outcount = 0;
                    if (writer != null)
                        writer.Close();
                    outfile = string.Format(outfileformatter, filecounter);
                    writer = new StreamWriter(outfile);
                }
                writer.Write(chunk);
                outcount += Encoding.UTF8.GetBytes(chunk).Length;
                //if the file is only ascii you could cheat and just say 'chunk.Length'.
            }
        }
    }
    if (writer != null)
        writer.Close();
