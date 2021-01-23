    messageControl1.SuspendLayout(); //add
    while (x < 20)
    {
        messageControl1.Add("Testing", MessageControl.BubblePositionEnum.Right);
        messageControl1.Add("Testing", MessageControl.BubblePositionEnum.Right);
        messageControl1.Add("Testing", MessageControl.BubblePositionEnum.Left);
        x++;
    }
    messageControl1.ResumeLayout(); //add
    messageControl1.Invalidate();   //add
