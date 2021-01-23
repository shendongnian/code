    Excel.Range chartRange;
    Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
    Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
    
    Excel.Chart chartPage = myChart.Chart;
    chartRange = xlWorkSheet.get_Range("A1", "C12"); // your data grid range
                
    chartPage.SetSourceData(chartRange, misValue); 
    chartPage.ChartType = Excel.XlChartType.xlConeCol;//xlCylinderCol;//xlLine;//xlColumnClustered;
    
    //export chart as picture file
    
    chartPage.Export(@"H:\img\excel_chart_export.png", "PNG", misValue);
       
