    public override void  Input0_ProcessInput(Input0Buffer Buffer)
    {
        while (Buffer.NextRow())
        {
            Input0_ProcessInputRow(Buffer);
        }
    }
    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        //Process one row's worth of data by calling "Row."
    }
