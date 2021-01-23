    picOneFaceUpA.Paint += (ss, ee) =>
    {
        if (picOneFaceUpA.BorderStyle == BorderStyle.FixedSingle)
            ee.Graphics.DrawRectangle(Pens.Orange, 0, 0,
                        picOneFaceUpA.ClientSize.Width - 1, 
                        picOneFaceUpA.ClientSize.Height - 1);
    };
