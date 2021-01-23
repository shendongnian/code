        public static string FileName
        {
            get
            {
                return "EXT_RF_ITAUVEST_201605091121212";
            }
        }
        [TestMethod()]
        public void ValidarNomeArquivo_DataNomeIncorreta_Mensagem()
        {
            //This try block must contain the entire function's logic, 
            // nothing can go after it to get the same behavor as ExpectedException.
            try
            {
                throw new Exception(String.Format("Error on file {0}", FileName));
                //This line must be the last line of the try block.
                Assert.Fail("No exception thrown");
            }
            catch(Exception e)
            {
                //This is the "AllowDerivedTypes=false" check. If you had done AllowDerivedTypes=true you can delete this check.
                if(e.GetType() != typeof(Exception))
                    throw;
                if(e.Message != String.Format("Error on file {0}", FileName))
                    throw;
                //Do nothing here
            }
        }
