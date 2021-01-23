    var ftpNazevF = TableObrazkyFTP.AsEnumerable().Select(r => r.Field<string>("nazevF"));
    var ftpRows = new HashSet<string>(ftpNazevF);
    
    var neniNaFtpRows = TableObrazkyD.AsEnumerable()
        .Where(row => !ftpRows.Contains(row.Field<string>("NAZEV_OBRAZKU")));
    DataTable neniNaFtpTable = null;
    if(neniNaFTPRows.Any())
        neniNaFtpTable = neniNaFtpRows.CopyToDataTable();
