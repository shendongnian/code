    Messenger.Default.Register<MyMessage>
    ( 
         this, 
         ( action ) => { lbl_text.Content = action.Text; }
    );
  
   
  
  
