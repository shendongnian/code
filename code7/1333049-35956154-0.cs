            [HttpGet]
            public ActionResult GetContractsDetailsForPdfCreation(int contentId)
            {
                ContractDetailsModel contractDetails = new ContractDetailsModel();
                
                try
                {
                    contractDetails = (ContractDetailsModel)contractBLObj.GetContractsDetailsForPdfCreation(contentId);
                }
                catch (Exception ex)
                {
                    
                }
                return new ViewAsPdf("ContractPDFDownload", contractDetails) 
                {
                    FileName = "ContractAgreement-"+contentId+".pdf"
                };
              
            }
