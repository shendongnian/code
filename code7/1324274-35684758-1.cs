    using System.Windows.Input;
    //[...]
    private bool ControlPressed
    {
        get
        {
           return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
        }
    }
    private bool E_Pressed
    {
        get
        {
            return Keyboard.IsKeyDown(Key.E);
        }
    }
