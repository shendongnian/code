        public List<FileDetails> IdentifyChanges()
    {
        logger.AddToLog("Change detection initiated...");
        //Deletes any existing cached package. Assuming it is in incosistent form
        logger.AddToLog( "Cleaning up any cached local package.");
      
      //Invalidate the control to redraw.
        logger.Invalidate();
      
        DeleteLocalPackage();
    } 
