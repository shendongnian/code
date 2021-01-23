    IEventProcessor _processor;
    // constructor
    public MyClass(IEventProcessor processor)
    {
       _processor = processor;
    }
    public void textbox1_TextChaned(object sender, EventArgs e)
    { 
        // pass whatever parameters you need to use in the method
        _processor.ProcessText1Changed(textbox1.Text);
    }
