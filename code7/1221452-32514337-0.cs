    // this is the variable that holds the enumerator instance 
    // once printing has started
    IEnumerator<Tuple<Object, LineTypes>> ObjectsEnumerator;
    
    // this is the event raised by printdocument at the start of printing
    private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        this.ObjectsEnumerator = Objects.GetEnumerator();
    }
