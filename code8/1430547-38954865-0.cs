    byte[] DataBytes= System.IO.File.ReadAllBytes(PieChartPath);
    System.IO.MemoryStream ms = new System.IO.MemoryStream(DataBytes);
    
    System.Drawing.Image PieChart = System.Drawing.Image.FromStream(ms);
    
