    protected void Page_Load(object sender, EventArgs e){
      //Please check for below line code
      this.button_Search.clicked += CallStoredProc;
     }
    
    protected void CallStoredProc(object sender, EventArgs e){
    // Here the SP could be called
    }
