    public interface ITerminalContext
    {
        ITerminalContext DoBtn1();
        ITerminalContext DoBtn2();
        ...
        // Get the context by index of the combobox
        ITerminalContext this[Int32 combobox]
        {
            get;
        }        
        // We will need it to return to the initial menu in the end
        ITerminalContext Parent {get; set;}
    }
