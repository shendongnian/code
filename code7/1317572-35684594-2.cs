    		public ActionResult YourMethod(string data)
    		{
    			//create pdf
    			var pdfBinary = Convert.FromBase64String(data);
    			var dir = Server.MapPath("~/DataDump");
    
    			if (!Directory.Exists(dir))
    				Directory.CreateDirectory(dir);
    
    			var fileName = dir + "\\PDFnMail-" + DateTime.Now.ToString("yyyyMMdd-HHMMss") + ".pdf";
    
    			// write content to the pdf
    			using (var fs = new FileStream(fileName, FileMode.Create))
    			using (var writer = new BinaryWriter(fs))
    			{
    				writer.Write(pdfBinary, 0, pdfBinary.Length);
    				writer.Close();
    			}
                //Mail the pdf and delete it
                // .... call mail method here 
               return null; 
    }
