    private void button4_Click(object sender, EventArgs e)
    {
        if (index > 0)
        {
            index--;
            this.Controls.RemoveByKey("txt" + index);
            this.Controls.RemoveByKey("lbl" + index);
            this.Height -= 30;
        }
    }
