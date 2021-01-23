    var oemResultsModels = new List<OemResultsModel>
    								   {
    									   new OemResultsModel
    									   {
    										   FirstName = "Fname1",
    										   LastName = "LName1",
    										   MessageType = "Type1",
    										   Phone = 1234567,
    										   SenderMessageReceived = "something1",
    										   SenderMessageSent = "somethingelse1",
    										   Sucess = true,
    										   Username = "username1"
    									   },
    									   new OemResultsModel
    									   {
    										   FirstName = "Fname2",
    										   LastName = "LName2",
    										   MessageType = "Type2",
    										   Phone = 123456789,
    										   SenderMessageReceived = "something2",
    										   SenderMessageSent = "somethingelse2",
    										   Sucess = false,
    										   Username = "username2"
    									   }
    								   };
    
    			using (var textWriter = File.CreateText(@"C:\destinationfile.csv"))
    			{
    				foreach (var line in ToCsv(oemResultsModels))
    				{
    					textWriter.WriteLine(line);
    				}
    			}
