    private void SomeFunction(){
        BLSecurity BLSecurity = new BLSecurity();      //here lies the problem
        if(BLSecurity.IsLoggedIn()){
            ...
        } else {
            ...
        }
    }
