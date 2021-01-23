        private string msValidationError;
        public string validateXML(XmlTextReader reader, string sDTDPath)
        {
	        System.Xml.XmlReaderSettings oSettings = new System.Xml.XmlReaderSettings();
	        oSettings.ValidationType = ValidationType.DTD;
	        oSettings.ValidationEventHandler += ValidationCallBack;
	        System.IO.Directory.SetCurrentDirectory(sDTDPath); //Set dtd folder		        
	        System.Xml.XmlReader oReader = System.Xml.XmlReader.Create(reader, oSettings);
            try
            {
                msValidationError = "";
                while (oReader.Read())
                {
                }
                oReader.Close();
                if (!string.IsNullOrEmpty(msValidationError))
                {
                    return string.Format("Invalid xml! {0}",msValidationError);
                }
            }
            catch (Exception ex)
            {
                return "Invalid xml.";
            }
            finally
            {
                try
                {
                    oReader.Close();
                }
                catch (Exception exI)
                {                    
                }
            }
	        return msValidationError;
        }
        private void ValidationCallBack(object sender, System.Xml.Schema.ValidationEventArgs args)
        {	
	        msValidationError = msValidationError + args.Message;
        }
