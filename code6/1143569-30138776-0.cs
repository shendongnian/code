    private Users_AboutMe objAMe;  
    
    public Users_AboutMe ObjAMe {
       get {
            if (objAMe == null) {
               objAMe =  new Users_AboutMe();
            }
            return objAMe;
       }
       set {
            objAMe = value;
        }
     }
