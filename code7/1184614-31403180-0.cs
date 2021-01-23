       public string phoneformat(string phnumber)
       {
         String phone=phnumber;
         string countrycode = phone.Substring(0, 3); 
         string Areacode = phone.Substring(3, 3); 
         string number = phone.Substring(6,phone.Length); 
         phnumber="("+countrycode+")" +Areacode+"-" +number ;
         return phnumber;
       }
