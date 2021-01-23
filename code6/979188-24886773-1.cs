            foreach (int listRow in rowList)
            {
                SortedList<int, string> columnList = new SortedList<int, string>();
                foreach(string row in filteredLines)
                {
                    int rowIndex = Convert.ToInt32(row.Substring(1, 2));
                    if(rowIndex==listRow)
                    {
                        int columnIndex = Convert.ToInt32(row.Substring(4, 2));
                        string value = row.Remove(0, 7);
                        if(columnList.ContainsKey(columnIndex))
                        {
                            columnList[columnIndex] = columnList[columnIndex] + value;
                        }
                        else
                        {
                            columnList.Add(columnIndex, value);
                        }
                    }
                }
                string concatenatedColumns = "";
                foreach(string col in columnList.Values)
                {
                    concatenatedColumns = concatenatedColumns + col;
                }
                parsedAndSortedRows.Add(concatenatedColumns);
            }
