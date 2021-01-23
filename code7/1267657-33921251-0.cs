    using System.IO;
    namespace ConsoleApplication1
    {
        class Program3
        {
            static void Main(string[] args)
            {
                using (var writer = new StreamWriter("output.csv"))
                using (var reader = new StreamReader("input.txt"))
                {
                    writer.WriteLine("movie,song,info");
                    string movie = "";
                    string song = "";
                    string info = "";
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                    
                        // movie
                        if (line.StartsWith("# "))
                        {
                            // forget previous song & info
                            song = "";
                            info = "";
                            // remember movie
                            movie = line.Substring(2);
                        }
                        // song
                        else if (line.StartsWith("- "))
                        {
                            // write song info to csv
                            if (song != "")
                            {
                                writer.WriteLine("\"" + movie + "\", \"" + song + "\", \"" + info + "\"");
                            }
                            // forget previous song info
                            info = "";
                            // remember song
                            song = line.Substring(2);
                        }
                        // song info
                        else if (line.StartsWith("  "))
                        {
                            // remember info
                            if (info != "")
                            {
                                info += "";
                            }
                            info += line;
                        }
                        // end of movie
                        else if (line == "")
                        {
                            // write song info to csv
                            if (song != "")
                            {
                                writer.WriteLine("\"" + movie + "\", \"" + song + "\", \"" + info + "\"");
                            }
                            // forget movie, song & info
                            movie = "";
                            song = "";
                            info = "";
                        }
                    }
                
                    // write song info to csv
                    if (song != "")
                    {
                        writer.WriteLine("\"" + movie + "\", \"" + song + "\", \"" + info + "\"");
                    }
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
