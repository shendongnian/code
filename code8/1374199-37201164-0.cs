    public partial class ButtonHasList : Button
    {
        public List<Textbox> List { get; set ;  }
        public  ButtonHasList() 
        {
             List = new     List<Textbox> ();
             this.Click += CleanTextOfList;
        }
        private void  CleanTextOfList ( object sender,EventArgs e)
       {
              foreach ( var item in List)
              {
                       item.Text = "";
               }
        }  
    }
