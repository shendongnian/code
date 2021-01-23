    tabControl1.Height = 10080;
    tabPage2.Height = 10050;
    dataGridView1.Height = 10000;
    dataGridView1.Rows.Add(3000);
    for (int i = 0; i < dataGridView1.Rows.Count; i++)  dataGridView1[0, i].Value = i;
    using (Bitmap bmp = new Bitmap(tabControl1.Width , tabControl1.Height ))
    {
        tabControl1.DrawToBitmap(bmp, tabControl1.ClientRectangle);
        bmp.Save("D:\\xxxx.png", ImageFormat.Png);
    }
