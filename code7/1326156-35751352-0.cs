        public string SaveTransaction(XElement pTransactionXml, string pSavePath)
        {
            
            //save the transaction to the drive locally
			pTransactionXml.Save(pSavePath);
            ...
			var mongoTask = Task.Run(async () =>
			{
				await SendXMLFilesToMongo(pSavePath);
			});
			
			return response.WithResult("Successfully saved to disk.");
        }
		
		public virtual async Task<int> SendXMLFilesToMongo(string pSavePath)
		{
             //call the code to save to mongo and do additional processing
        }
