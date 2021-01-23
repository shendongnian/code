    using PowerPoint = Microsoft.Office.Interop.PowerPoint;
    
    namespace SampleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var filePath = @"C:\users\userx\desktop\test.pptx";
                var app = new PowerPoint.Application();
                var presentation = app.Presentations.Open(filePath);
                var slide = presentation.Slides[1];
                var chart = slide.Shapes[1].Chart;
                var series = chart.SeriesCollection(1) as PowerPoint.Series;
                var point = series.Points(1) as PowerPoint.Point;
                point.Interior.Color = 0x41BA5D;
                point = series.Points(2) as PowerPoint.Point;
                point.Interior.Color = 0xA841BA;
                point = series.Points(3) as PowerPoint.Point;
                point.Interior.Color = 0xBA4141;
                point = series.Points(4) as PowerPoint.Point;
                point.Interior.Color = 0x7AB4FF;
            }
        }
    }
