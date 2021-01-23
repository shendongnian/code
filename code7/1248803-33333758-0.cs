    var cache= new new Queue<string>();
    
     using (StreamReader reader = new StreamReader("file.txt"))
    	{
            cache.Enqueue(reader.ReadLine());
            if(cache.Count() > 11)
                 cache.Dequeue(); // clear old stuff
    
            if(cache.Count() == 11) // now you have your 5 before and 5 after
                {
                  var myRow = cache.ElementAt(6); // do stuff
                }
    	}
