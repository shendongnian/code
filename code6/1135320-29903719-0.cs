    public class MyDataGridTextColumn :DataGridTextColumn 
    {
       public int ColumnIndex {get;private set;}
       public MyDataGridTextColumn (int columnIndex)
       {
           ColumnIndex = columnIndex;
       }
    }
    
