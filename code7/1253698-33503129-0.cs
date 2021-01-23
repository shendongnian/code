    public class CustomWebClient {
        public enum Headers { StandardForm, Json, Xml }
    
        public CustomWebClient() {
        }
    
        //This is your original UploadString.
        public string UploadString(string x, string y) {
            //Call the overload with default header.
            UploadString("...", "...", Headers.StandardForm);
        }    
    
    
        //This is the overloaded UploadString.
        public string UploadString(string x, string y, Headers header) {
           switch(header){
           case Headers.StandardForm:
               client.Headers.Add("Content-Type","application/x-www-form-urlencoded");
               break;
           case Headers.Json:
               client.Headers.Add("Content-Type","text/json");
               break;
           case Headers.Xml:
               client.Headers.Add("Content-Type","text/xml");
               break;
           }
           //Continue your code.
        }    
    }
