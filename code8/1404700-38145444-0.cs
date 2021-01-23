      MessageDialog msgDialog = new MessageDialog("message here... ", "title here");
      //add ok button
      UICommand okBtn = new UICommand("OK");
      okBtn.Invoked = OkBtnClick;
      msgDialog.Commands.Add(okBtn);
      //add cancel button
      UICommand cancelBtn = new UICommand("Cancel");
      cancelBtn.Invoked = CancelBtnClick;
      msgDialog.Commands.Add(cancelBtn);
      //show message
      await msgDialog.ShowAsync();
    //code for cancel click
    private void CancelBtnClick(IUICommand command)
    {
    }
    
    //code for ok click
    private void OkBtnClick(IUICommand command)
    {
    }
