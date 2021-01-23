    string str = "a string with some CAP letters and 123numbers";
    void Start(){
        string result = KeepaToz(str);
        Debug.Log(result); // print "astringwithsomelettersandnumbers"
    }
    string KeepaToz(string input){
       StringBuilder sb = new StringBuilder();
       foreach(char c in str){
           if(c >= 97 && c<= 122){ sb.Append(c); }
       }
       return sb.ToString();
    }
