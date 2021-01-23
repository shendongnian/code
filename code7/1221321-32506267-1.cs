    public int[,] setupState ()
        {
             int[,] startArray = new int[5, 5] // 2 Dem array using 0 as empty and 1 as full and 3 as not valid location. 
            {
                { 0, 1, 1, 1, 1  },
                { 1, 1, 1, 1, 3  },
                { 1, 1, 1, 3, 3  },
                { 1, 1, 3, 3, 3  },
                { 1, 3, 3, 3, 3  }};
            return startArray;
        }  
    private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Testing Button");
            int[,] cState = new int[5, 5];
            cState = setupState();
            if (cState.Length > 0)
            {
                StringBuilder col = new StringBuilder();
                StringBuilder row = new StringBuilder();
                for (int i = 0; i < cState.GetLength(0); i++)
                    for (int j = 0; j < cState.GetLength(1); j++)
                        col.Append(", ").Append(cState[i, j]);
                        //row.Append(", ").Append(cState[i, j]);
                        textBox1.Text = col.ToString();
            }
        }
