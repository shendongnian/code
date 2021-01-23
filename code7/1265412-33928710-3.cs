    public static void ExportDataTableToDelimitedFile(DataTable table, string filename, string encloseWith, string delimiter, bool includeHeader, string fieldsToExclude, bool fixedLengthValues)
    {
        String excludeList = String.Empty;
        if (!String.IsNullOrEmpty(fieldsToExclude))
        {
            excludeList = fieldsToExclude.ToUpper();
        }
        using (FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite, 2097152, FileOptions.None))
        {
            BinaryWriter sw = new BinaryWriter(fs);
            if (table.Rows.Count == 0)
            {
                sw.Write(String.Empty);
                sw.Close();
                sw.Dispose();
                return;
            }
            //Handle header
            if (includeHeader)
            {
                string header = String.Empty;
                String formattedHeader = String.Empty;
                foreach (DataColumn clm in table.Columns)
                {
                    if (excludeList.Contains(clm.ColumnName.ToUpper()))
                        continue;
                    if (clm.ColumnName.Length > 0)
                    {
                        formattedHeader = String.Empty;
                        formattedHeader = encloseWith + clm.ColumnName + encloseWith;
                        if (header.Length > 0)
                            header = String.Join(delimiter, new string[] { header, formattedHeader });
                        else
                            header = formattedHeader;
                    }
                }
                sw.Write(header);
            }
            // handle  values in data rows now
            Boolean hasEnlosedCharacter = !String.IsNullOrEmpty(encloseWith);
            Parallel.ForEach(table.Rows.Cast<DataRow>(), row =>
            {
                char[] rowValue = new char[8192];
                Int32 rowValueIndex = 0;
                char[][] rowData = row.ItemArray.Select(field => field.ToString().ToCharArray()).ToArray();
                for (int i = 0; i < rowData.Length; i++)
                {
                    Boolean useEnclosed = rowData[i].Length > 0 && hasEnlosedCharacter;
                    if (rowValueIndex > 0)
                    {
                        if (useEnclosed)
                        {
                            rowValue[rowValueIndex++] = delimiter[0];
                            rowValue[rowValueIndex++] = encloseWith[0];
                            rowData[i].CopyTo(rowValue, rowValueIndex);
                            rowValueIndex += rowData[i].Length;
                            rowValue[rowValueIndex++] = encloseWith[0];
                        }
                        else
                        {
                            rowValue[rowValueIndex++] = delimiter[0];
                            rowData[i].CopyTo(rowValue, rowValueIndex);
                            rowValueIndex += rowData[i].Length;
                        }
                    }
                    else
                    {
                        if (useEnclosed)
                        {
                            rowValue[rowValueIndex++] = encloseWith[0];
                            rowData[i].CopyTo(rowValue, rowValueIndex);
                            rowValueIndex += rowData[i].Length;
                            rowValue[rowValueIndex++] = encloseWith[0];
                        }
                        else
                        {
                            rowData[i].CopyTo(rowValue, rowValueIndex);
                            rowValueIndex += rowData[i].Length;
                        }
                    }
                }
                rowValue[rowValueIndex++] = '\r';
                rowValue[rowValueIndex++] = '\n';
                lock (sw)
                {
                    sw.Write(rowValue, 0, rowValueIndex);
                }
            });
            sw.Close();
            sw.Dispose();
            table.Dispose();
            fs.Close();
        }
    }
