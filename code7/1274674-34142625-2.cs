    void Main()
        {
        	var levelInfo = XDocument.Load(@"C:\test\data.xml");
        	
        	var serialiser = new XmlSerializer(typeof(Level));
        	foreach (var level in levelInfo.Root.Descendants("record"))
        	{
        	   Level newLevel = null;
        	  using (var reader = level.CreateReader())
              {
        	    try
        		{
                	newLevel = serialiser.Deserialize(reader) as Level;
        		}
        	  	catch(Exception)
        		{
        	    	//something went wrong with de-serialisation!
        		}
                Console.WriteLine("Level.LevelNum={0}, evel.LevelSeq.SeqLinear=",
                                 newLevel.LevelNum,newLevel.Seq.SeqLinear);     
        	 }
           }
        }
