            public static List<XL.Chart> ReturnSelectedCharts(dynamic selection )
        {
            List<XL.Chart> charts=new List<XL.Chart>();
            XL.ShapeRange selectedShapeRange = null;
            XL.Chart chart=null;
            try
            {
                selectedShapeRange = Globals.ThisAddIn.Application.Selection.ShapeRange;
                for (int i = 1; i <= selectedShapeRange.Count; i++)
                {
                    XL.Shape shape=selectedShapeRange.Item(i);
                    if (shape.HasChart==MsoTriState.msoTrue)
	                {
                        chart = shape.Chart;
                        charts.Add(chart);
	                }
                    
                }
            }
            catch
            {
            }
            if (charts.Count==0)
            {
                try
                {
                    chart = Globals.ThisAddIn.Application.ActiveChart;
                    charts.Add(chart);
                }
                catch (Exception)
                {
                }
            }
            return charts;
        }
