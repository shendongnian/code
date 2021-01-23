    DataSet dataSet = new DataSet();
    dataSet.ReadXml(xmlFilePath);
    string sort = sortColumn + " " + OrderDirection;
    DataTable table = dataSet.Tables["Orders"].Select("", sort)
                                              .Skip(lowerPageBoundary - 1 * rowsPerPage)
                                              .Take(rowsPerPage)
                                              .CopyToDataTable();
    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
