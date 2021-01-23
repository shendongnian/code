	[HttpPost]
	public ActionResult UploadValidationTable(HttpPostedFileBase csvFile)
	{
	    var inputFileDescription = new CsvFileDescription
	    {
	        SeparatorChar = ',',
	        FirstLineHasColumnNames = true
	    };
	    var cc = new CsvContext();
	    var filePath = uploadFile(csvFile.InputStream);
	    var model = cc.Read<Credit>(filePath, inputFileDescription);
	
	    try
	    {
	        var entity = new TestEntities();
	        var tcIdFound = new HashSet<string>();
	        
	        foreach (var item in model)
	        {
							if (tcIdFound.Contains(item.Id)) 
							{
								continue;
							}			        
			        
		        var tc = new TemporaryCsvUpload();
            	tc.Id = item.Id;
	            tc.CreditInvoiceAmount = item.CreditInvoiceAmount;
	            tc.CreditInvoiceDate = item.CreditInvoiceDate;
	            tc.CreditInvoiceNumber = item.CreditInvoiceNumber;
	            tc.CreditDeniedDate = item.CreditDeniedDate;
	            tc.CreditDeniedReasonId = item.CreditDeniedReasonId;
	            tc.CreditDeniedNotes = item.CreditDeniedNotes;
	            
	            entity.TemporaryCsvUploads.Add(tc);
	        }
	
	        entity.SaveChanges();
	        entity.Database.ExecuteSqlCommand("TRUNCATE TABLE TemporaryCsvUpload");
	
	        TempData["Success"] = "Updated Successfully";
	
	    }
	    catch (LINQtoCSVException)
	    {
	        TempData["Error"] = "Upload Error: Ensure you have the correct header fields and that the file is of .csv format.";
	    }
	
	    return View("Upload");
	}
