    var batchSize = 50;
            
    for(int i = 0; i<collection.Count ; i+=batchSize)
    {
         using (var cnn = new SqlConnection())
         {
          int j = 0
          foreach (var item in collection.Skip(i))
          {
    		if(j++ == batchSize) continue;
    		
             //do stuff     
             SaveImage(item.filename,item.img);     
          }
         }
    }
