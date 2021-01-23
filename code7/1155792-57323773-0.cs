       WebPageModel webPageModelSave = new WebPageModel();
                    webPageModelSave = ObjectCopier.CloneClass(Public.CashEntity.webPageModel);
                    webPageModelSave.Address = uxLabel_AddressTitle.Text;
    
                    string codeingData = JsonConvert.SerializeObject(webPageModelSave);
                   codeingData = ArmanSerialize.CryptoString.Encrypt(codeingData, "5552552");
                    string resutlt = await Public.Helper.ApiServer.PutWebPage("123", "\""+codeingData+"\"");
