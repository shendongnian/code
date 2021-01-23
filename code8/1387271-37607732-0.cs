    Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)ws.Cells[3, 1];
    float Left = (float)((double)oRange.Left);
    float Top = (float)((double)oRange.Top);
    const float ImageSize = 32;
    ws.Shapes.AddPicture("C:\\pic.JPG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
