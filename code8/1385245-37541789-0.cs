    void UpdateGridColumnLabels(int index){
        int width = column.Width;
        int height = gridRow.Height;
        Bitmap bmp = new Bitmap(width, height, g);
        Graphics g = Graphics.FromImage(bmp);
        if(value < 20)
            g.FillRect(Brushes.Red, 0, 0, width / 3, height);
        else if(value >= 20 && value < 40)
            g.FillRect(Brushes.Orange, width/3, 0, width / 3, height);
        else
            g.FillRect(Brushes.Yellow, 2 * width/3, 0, width / 3, height);
        gridViewImageColumn[index] = bmp;
    }
