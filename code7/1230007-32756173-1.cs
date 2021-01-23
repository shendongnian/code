    //Logical focus
     var focusedControl = FocusManager.GetFocusedElement(this);
    
    //KeyBoard focus
     var focusedControl =  Keyboard.FocusedElement;
    
    List<TextBox> items=new List<TextBox>();
    items.Add(TextBoxExtendedSearchName);
    items.Add(TextBoxExtendedSearchNomenclature);
    items.Add(TextBoxExtendedSearchSpecialist);
    if(items.Any(o=>o==focusedControl))
     {
        window.Close();
     }
