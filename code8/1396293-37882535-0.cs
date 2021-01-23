    var ftpNazevF = TableObrazkyFTP.AsEnumerable().Select(r => r.Field<string>("nazevF"));
    var ftpRows = new HashSet<string>(ftpNazevF);
    
    var onlyInTable1Rows = TableObrazkyD.AsEnumerable()
        .Where(row => !ftpRows.Contains(row.Field<string>("NAZEV_OBRAZKU")));
    DataTable onlyInTable1 = null;
    if(onlyInTable1Rows.Any())
        onlyInTable1 = onlyInTable1Rows.CopyToDataTable();
