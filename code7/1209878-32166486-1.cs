    private void button4_Click(object sender, EventArgs e)
    {
       int totalmarks = 0;
       foreach(int m in marks)
        totalmarks += m;
      MessageBox.Show("Average Is: " + totalmarks / marks.Count);
    }
