    class IndexPath {
      public int Row { get; set; }
    
      public IndexPath(int row) { this.Row = row; }
    }
    
    class Row {
      public Heading Heading { get; set; }
    
      public Row(Heading heading) { this.Heading = heading; }
    }
    
    class Heading {
    }
    
    var tableItems = new Dictionary<int, Row>();
    tableItems.Add(0, new Row(new Heading());
    tableItems.Add(1, new Row(new Heading());
    // ... and so on
    
    var indexPath = new IndexPath(1);
    tableItems[indexPath.Row].Heading;
