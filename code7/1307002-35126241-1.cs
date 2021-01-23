    public void LoadPage(string Format, bool isFindAndReplace = false) {
        int replaced = 0;
    
        ....
    
        if ((column[i]).Contains(StaticVar.Find) != null) {                                          
            dataGridView1.Rows[rowindex].Cells[index].Value = column[i].Replace(StaticVar.Find, StaticVar.Replace);
            replaced++;
        }
    
        ....
    
        if(isFindAndReplace)
            MessageBox.Show(string.Format("{0} occurrence(s) replaced.", replaced));
    }
