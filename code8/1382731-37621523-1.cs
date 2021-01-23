    private void List_PreviewMouseLeftButtonDown (object Sender, MouseEventArgs E)
    {
      var fs = GetFocusScope(myComboBox);
      IInputElement fe = FocusManager.GerFocusedElement(fs);
      
      if (fe == myListView)
      {
          startPoint_ = E.GetPosition (null);
      }
    }
