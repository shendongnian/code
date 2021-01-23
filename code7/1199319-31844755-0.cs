    class Sheet {
      public List<Row> Rows { get; set; }
    }
    public class Row {
      public string Dummy { get; set; }
      public List<Cell> Cells { get; set; } 
    }                                        
    public class Column {
      public string Name { get; set; }
      public ValueType ValueType { get; set; }
    }
    public class Cell {
      public Column Column { get; private set; }
      public object Data { get; private set; }
  
      public int GetValueInt() {
        return Column.ValueType == ValueType.Number ? (int)Data : 0;
      }
    
      public string GetValueString() {
        // could also return Data.ToString() is Data is not null
        return Column.ValueType == ValueType.String ? (string)Data : null;
      }
    
      public decimal GetValueCurrenty() {
        return Column.ValueType == ValueType.Currency ? (decimal)Data : 0;
      }
    
      // factory for cells
      public static Cell MakeCell(object data, Column column) {
    
        // fail-early if the data does not match the value type specified by the column
        switch (column.ValueType) {
            case ValueType.String:
            if (!(data is string)) {
              throw new ArgumentException("Invalid data for column containing strings");
            }
            break;
              
            case ValueType.Number:
            if (!(data is int)) {
              throw new ArgumentException("Invalid data for column containing ints");
            }
            break;
    
            case ValueType.Currency:
            if (!(data is decimal)) {
              throw new ArgumentException("Invalid data for column containing decimals");
            }
            break;
       }
    
      var cell = new Cell { Column = column, Data = data };
      return cell;
    }
  }
 
