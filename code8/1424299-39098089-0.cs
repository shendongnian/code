     private void EditTextOnFocusChanged(object sender, FocusChangeEventArgs focusChangedEventArgs)
        {
            if ( focusChangedEventArgs.HasFocus )
                ViewSaver.SetLastView(Element.ClassId);
        }
    view.EditText.FocusChange += EditTextOnFocusChanged;
