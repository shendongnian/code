    [Serializable]
    class ControlFactory
    {
        enum ControlType
        {
            TextBox
        }
        ControlType Type {get;set;}
        Point Position {get;set;}
        //etc.
        Control Create()
        {
            switch(Type)
            {
                case ControlType.TextBox:
                    TextBox txt = new Textbox();
                    // apply settings
                    return txt;
            }
        }
    }
