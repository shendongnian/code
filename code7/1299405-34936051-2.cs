        public Dictionary<String, List<OpenXmlElement>> ToSheets(DataSet ds)
        {
            return
                (from dt in ds.Tables.OfType<DataTable>()
                 select new
                 {
                     Key = dt.TableName,
                     Value = (
                     new List<OpenXmlElement>(
                        new OpenXmlElement[] 
                {
                    new Row(
                        from d in dt.Columns.OfType<DataColumn>()
                        select (OpenXmlElement)new Cell()
                        {
                            CellValue = new CellValue(d.ColumnName),
                            StyleIndex = 1,
                            DataType = CellValues.String
                        })
                })).Union
                     ((from dr in dt.Rows.OfType<DataRow>()
                       select ((OpenXmlElement)new Row(from dc in dr.ItemArray
                                                       select (OpenXmlElement)new Cell()
                                                       {
                                                           CellValue = new CellValue(dc.ToString()),
                                                           DataType = CellValues.String,
                                                           StyleIndex = styleIdentifier(dc.ToString())
                                                       })))).ToList()
                 }).ToDictionary(p => p.Key, p => p.Value);
        }
