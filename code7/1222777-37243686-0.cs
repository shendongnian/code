    //Start an hidden excel application
    var appExcel = new Excel.Application { Visible = false }; 
    var workbook = appExcel.Workbooks.Add();
    var sheet = workbook.ActiveSheet;
    //Generate some random data
    Random r = new Random();
    for (int i = 1; i <= 10; i++)
    {
        sheet.Cells[i, 1].Value2 = ((char)('A' + i - 1)).ToString();
        sheet.Cells[i, 2].Value2 = r.Next(1, 20);
    }
    //Select the data to use in the treemap
    var range = sheet.Cells.Range["A1", "B10"];
    range.Select();
    range.Activate();
    //Generate the chart
    var shape = sheet.Shapes.AddChart2(-1, (Office.XlChartType)117, 200, 25, 300, 300, null);
    shape.Chart.ChartTitle.Caption = "Generated TreeMap Chart";
    //Copy the chart
    shape.Copy();
    appExcel.Quit();
            
    //Start a Powerpoint application
    var appPpoint = new Point.Application { Visible = Office.MsoTriState.msoTrue };            
    var presentation = appPpoint.Presentations.Add();
    //Add a blank slide
    var master = presentation.SlideMaster;
    var slide = presentation.Slides.AddSlide(1, master.CustomLayouts[7]);
    //Paste the treemap
    slide.Shapes.Paste();
