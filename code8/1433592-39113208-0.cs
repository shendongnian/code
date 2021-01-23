    private void pnlDesign_MouseClick(object sender, MouseEventArgs e)
    {
        Point point = pnlDesign.PointToClient(Cursor.Position);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        int listCount = 0;
        for (listCount = 0; listCount < number * number; listCount++)
        {
            if (listRec[listCount].Contains(point))
            {
                g.FillRectangle(blueBrush, listRec[listCount]);
            }
        }
    }
