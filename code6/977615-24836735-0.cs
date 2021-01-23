    private void mainLogDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
       if (((DataGridView)sender).Name == dataGridView1.Name) 
       { '//Grid one Process }
       else if (((DataGridView)sender).Name == dataGridView2.Name) 
       { '//Grid TweProcess  }
    
    }
    
    private void filteredLogDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
          if (((DataGridView)sender).Name == dataGridView1.Name) 
          { '//Grid one Process }
          else if (((DataGridView)sender).Name == dataGridView2.Name) 
          { '//Grid TweProcess  }
    }
