    Worksheet ws = wb.Worksheets.get_Item("French");
    // Check for protection and unlock the worksheet
    If ws.ProtectContents {
        ws.Unprotect("PROTECTION_PASSWORD");
    }
    ws.Select(Type.Missing);
    
    ws.Range["E5"].Value = StartDate;  // <- Crashes here
    ws.Range["G5"].Value = EndDate;
