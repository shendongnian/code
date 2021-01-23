    public bool CheckUri(Uri uri){
       using(var client = new WebClient()){
      
       try{
            client.DownloadFile(uri);
            return true;
        }catch{//error detected
         return false;
       }
      }
     }
