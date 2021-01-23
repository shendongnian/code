    Mouse_Tracking mst = new Mouse_Tracking();
    private void btn_start_Click(object sender, EventArgs e)
    {
        mst = new Mouse_Tracking();
        .......
    }
    private void btn_stop_Click(object sender, EventArgs e)
    {
         mst.flag = 0;
    }
