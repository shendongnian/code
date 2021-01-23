    ....
    ....
    if (cropRect == true){
        if (recttest.Width > 10 && recttest.Height > 10){
            e.Graphics.FillRectangle(Brushes.White, 0, 0, pictureBoxSnap.Width, rect.Y);
            e.Graphics.FillRectangle(Brushes.White, 0, rect.Y, rect.X, rect.Height);
            e.Graphics.FillRectangle(Brushes.White, rect.X + rect.Width, rect.Y, pictureBoxSnap.Width - rect.X - rect.Width, rect.Height);
            e.Graphics.FillRectangle(Brushes.White, 0, rect.Y + rect.Height, pictureBoxSnap.Width, pictureBoxSnap.Height - rect.Y - rect.Height);
         }
    }    
