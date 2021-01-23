    class AssociationUriMapper : UriMapperBase{
       private string tempUri;
       public override Uri MapUri(Uri uri){
       tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
       if (tempUri.Contains("alsdkcs://MainPage")){
           return new Uri("/MainPage.xaml", UriKind.Relative); //we can return any existing page with parameter
        }
      return uri;
    }
