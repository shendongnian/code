    string mat = "test";
    for(int i=0;i<dataGridView1.Rows[0].Count;i++){
            if(mat == dataGridView1[0,i].Value.ToString())
            {
                tst.Text = dataGridView1[1,i].Value.ToString();
            }
    }
