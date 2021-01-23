      private double average(int firstRow,int RowsCount)
      { 
          double sum=0d;
          for (int i = firstRow; i < RowsCount; i++) 
          {
              for(int ii=0;ii<dataGridView1.Columns.Count;ii++)
              {
              sum +=Convert.ToDouble(dataGridView1[i,ii].Value);
              }
          }
          return sum/(RowsCount*dataGridView1[i].Columns.Count);
      } 
