    using System.Windows.Input;
    //[...]
    private bool ControlPressed//Returns true if the left control button or the right control button is pressed. Returns false if neither are pressed.
    {
        get
        {
           return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
        }
    }
    private bool E_Pressed//Boolean that returns true if "E" is pressed and false if it isn't.
    {
        get
        {
            return Keyboard.IsKeyDown(Key.E);
        }
    }
