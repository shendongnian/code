    public void reDraw()
    {
        box.Image.Dispose();
        Bitmap GraphBlankImage = new Bitmap(box.ClientSize.Width, box.ClientSize.Height);
        updatePointPerUnit();
        drawGrid(GraphBlankImage);
        box.Image = GraphBlankImage;
    }
