     class MyButton
        {
         delegate void ClickHandler(object o ,EventArgs e);
         public event ClickHandler Click;
         ......
        
          public List<ClickHandler> ClickHandlerList
          {
             get
              {
                  return ClickHandler.GetInovationList().Cast<ClickHandler>().ToList();
              }
           }
          public bool IsClickEventSubcribed
          {
             get
              {
                  return ClickHandler.GetInovationList().Cast<ClickHandler>().Any();
              }
           }
        }
