    protected void Page_Load(object sender, EventArgs args)
        {
          if(!IsPostBack)
        {
           DataBindLogic();
        }
        }
        
        private void DataBindLogic()
        {
          /*Put databind code here */
        }
        
        protected void RemoveBtn_Click(Object sender,Eventargs args)
        {
          /*Do db update */
          DataBindLogic();
        }
