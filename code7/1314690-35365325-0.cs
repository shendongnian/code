        const Int32 BufferSize = 128;
        int count = 0;
        int count2 = 0;
        string filename = @"C:\test\test.txt";
        string output = @"C:\text\output.txt";
        string Startcomment = @"<-comment 1:";
        string Startmoretext= @"<-Another line";
        string othercit = @"LINK:";
        string sub = @"<tag>&#x2014;</tag>";
        string subrepalce = @"_";
        string line;
        string[] fileText = File.ReadAllLines(filename);
        
            Console.WriteLine("Start time: " + DateTime.Now.ToString());
        Parallel.For(0, fileText.Length, i=>{
          if(!fileText[i].StartsWith(Startcomment) && !fileText[i].StartsWith(Startmoretext))
                    {
                        count2++;
                        if (fileText[i].StartsWith(othercit))
                        {
                            fileText[i]= fileText[i].Replace(sub, subrepalce);
                        }
                        File.WriteAllLines(yourPath, fileText);
                    }
                }                    
            }                
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(count + " Lines processed");
            Console.WriteLine(count2 + " Lines written back");
            Console.WriteLine("Finished!!!!!!");
            Console.Read();
        });
