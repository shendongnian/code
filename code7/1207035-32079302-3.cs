    string mat = "test";
    for(int i=0;i<dataGridView1.Rows[0].Cells.Count;i++){
            if(dataGridView1[0,i].Value != null && mat == dataGridView1[0,i].Value.ToString())
            {
                tst.Text = dataGridView1[1,i].Value.ToString();
            }
    }
