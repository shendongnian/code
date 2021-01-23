    var filename = "outfile.sql";
    var spliton = "INSERT INTO";
    var outcount = 0;
    var filecounter = 0;
    var outfileformatter = Path.GetFileNameWithoutExtension(filename) + "_{0}" +
                            Path.GetExtension(filename);
    string outfile = null;
    StreamWriter writer = null;
    var blocksize = 32 * 1024;
    var block = new char[blocksize];
    // by using StreamReader you won't have to load the entire file into memory
    using (var reader = new StreamReader(filename))
    {
        while (!reader.EndOfStream)
        {
            // read in sections of the file at a time since you can't hold the entire thing in memory.
            var outsize = reader.ReadBlock(block, 0, blocksize);
            var content = new string(block, 0, outsize);
            // split the data by your seperator.
            var chunks = content.Split(new[] { spliton }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(c => spliton + c);
            // loop over the chunks of data 
            foreach (var chunk in chunks)
            {
                //once the threshold is tripped close the writer and open the next
                if (outcount > 48 * 1024  * 1024 || outfile == null) //48MB 
                {
                    filecounter++;
                    outcount = 0;
                    if (writer != null)
                        writer.Close();
                    Console.WriteLine(outfile);
                    outfile = string.Format(outfileformatter, filecounter);
                    writer = new StreamWriter(outfile);
                }
                //output the data
                writer.Write(chunk);
                //record how much data you wrote to the file.
                outcount += Encoding.UTF8.GetBytes(chunk).Length;
                //if the file is only ascii you could cheat and just say 'chunk.Length'.
            }
        }
    }
    if (writer != null)
        writer.Close();
