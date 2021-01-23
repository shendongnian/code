    private void pictureBoxSnap_Paint(object sender, PaintEventArgs e){
        Point pnt;
        ....
        ....
        if (cropRect == true){
            if (recttest.Width > 10 && recttest.Height > 10){
                pnt = PointToScreen(pictureBoxSnap.Location);
                e.Graphics.Clear(Color.White);
                e.Graphics.CopyFromScreen(pnt.X + rect.X, pnt.Y + rect.Y, rect.X, rect.Y, New Size(rect.Width, rect.Height));
            }
        }
