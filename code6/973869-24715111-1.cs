    String line;
    
    try 
    {
      line = txtrdr.ReadLine();       //call ReadLine on reader to read each line
      while (line != null)            //loop through the reader and do the write
      {
       Console.WriteLine(line);
       line = txtrdr.ReadLine();
      }
    }
    
    catch(Exception e)
    {
      // Do whatever needed
    }
    
    
    finally 
    {
      if(txtrdr != null)
       txtrdr.Close();    //close once done
    }
