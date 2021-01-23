    int imgIndex = 0;
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
            
        if (e.ColumnIndex == 1)
            e.Graphics.DrawImage(imageList1.Images[imgIndex], e.Bounds);
        else e.DrawDefault = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        imgIndex++;
        listView1.Invalidate();
    }
