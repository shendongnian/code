    //When you have the UITechnologyElement, you can create a WinControl from it by using this methode
    WinControl result = (WinControl)UITestControlFactory.FromNativeElement(control.NativeElement, "MSAA");
    //Now you have the WinControl so you can convert it into a special Type, eg. WinButton
    WinButton wb = (WinButton)result;
    //And invoke the Mouse.Click methode
    Mouse.Click(wb, MouseButtons.Left);
