    BasicHttpBinding myBinding = new BasicHttpBinding();
     
    myBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    
    myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
    EndpointAddress ea = new EndpointAddress("url de mon web service soap");
    
    SfcServices.SFCProcessingInClient myClient = new SfcServices.SFCProcessingInClient(myBinding, ea);
    
    myClient.ClientCredentials.UserName.UserName = _MESwsLogin;
    myClient.ClientCredentials.UserName.Password = _MESwsPassword;
    
    SfcServices.SFCStateRequestMessage_sync srm = new SfcServices.SFCStateRequestMessage_sync();
    SfcServices.SFCStateRequest sr = new SfcServices.SFCStateRequest();
    srm.SfcStateRequest = sr;
    sr.SiteRef = new SfcServices.SiteRef();
    sr.SiteRef.Site = _MESsite;
    sr.SfcRef = new SfcServices.SFCRef();
    sr.SfcRef.Sfc = "12345678903";
    
    sr.includeSFCStepList = true;
    
    SfcServices.SFCStateConfirmationMessage_sync response = myClient.FindStateByBasicData(srm);
    strOrdreFab = response.SfcStateResponse.SFCStatus.Sfc.ShopOrderRef.ShopOrder;
    strCodeProduit = response.SfcStateResponse.SFCStatus.Sfc.ItemRef.Item;
    strIndice = response.SfcStateResponse.SFCStatus.Sfc.ItemRef.Revision;
