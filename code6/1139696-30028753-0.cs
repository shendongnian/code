    // Change alignment to center so you don't have to do the math yourself :)
    using (var format = new StringFormat() { Alignment = StringAlignment.Center })
    {
       ...
       // Translate to the point where you want the text
       g.TranslateTransform(result2.Width, result2.Height / 2);
       // Rotation happens around that point
       g.RotateTransform(-90);
       // Note that we draw on [0, 0] because we translated our coordinates already
       g.DrawString(inputData, font, brush, 0, 0, format);
       // When done, reset the transform
       g.ResetTransform();
    }
