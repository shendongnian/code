    Donot use DataImportProperties.UseColumnNames=true.Instead use cell specific formatting since it is header so for every cell row/column number is known.ex.     
    
        Style headerStyle = wb.CreateStyle();
                    headerStyle.Font.Size = 10;
                    headerStyle.Font.Bold = true;            
                    ws.Cells[1, 0].Value = "Name";
                    ws.Cells[1, 0].ApplyStyle(headerStyle);
    
    You can also merge and group columns  as :
                ws[0, 0].Value = "Information";
                Palette pal = wb.Palette;
                Color group1Color = pal.GetClosestColor(255, 244, 205);
                headerStyle.BackgroundColor = group1Color;
                headerStyle.Font.Bold = true;
                ws[0, 0].ApplyStyle(headerStyle);
                ws.CreateArea(0, 0, 1, 13).MergeCells();
                ws.GroupColumns(0, 12, true);
    //True/false keeps the group collapsed/uncollpasedwhen user opens the workbook.
