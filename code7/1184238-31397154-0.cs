    public async void getResult ()
    {
         ScannedItem scannedItem;
         try 
         {
    		scannedItem = await getScannedItem(); 
    		getResultsScannedItem = await results(scannedItem);   
    	 } catch (Exception exe) { }
    }
