    for(int i = firstBlock; i < lastBlock; i++)
	{
        if(mifc.IsConnected)
	    {
            DisplayMessage("Read Block " + i);
			System.Threading.Thread.Sleep(100);
		    byte[] block = mifc.ReadBlockAsync(i).Result;
			lstBlocks.Add(block);
		}
		else
		{
			DisplayMessage("Card Disconnected");
		} 
    }
