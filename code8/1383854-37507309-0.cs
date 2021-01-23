     class hhhmmCustomComparer : IComparable 
        {
            private static int sortOrderModifier = 1;
            private int columnIndex;
            public string stringValue;
            public hhhmmCustomComparer(int columnIndex, System.Windows.Forms.SortOrder sortOrder)
            {
                this.columnIndex = columnIndex;
                if (sortOrder == SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }
    
            public hhhmmCustomComparer(int hours, int Minutes)
            {
                stringValue = hours.ToString() + ":" + Minutes.ToString();
    
            }
    
            public int Compare(DataRow Row1, DataRow Row2)
            {
                int CompareResult = 0;
    
                if (String.IsNullOrEmpty(Row1[columnIndex].ToString()) && String.IsNullOrEmpty(Row2[columnIndex].ToString()))
                {
                    return 0;
    
    
                }
                else if (String.IsNullOrEmpty(Row1[columnIndex].ToString()))
                {
                    CompareResult = -1;
                }
                else if (String.IsNullOrEmpty(Row2[columnIndex].ToString()))
                {
                    CompareResult = 1;//1 , -1
                }
                else
                {
                    TimeSpan CellValue1 = new TimeSpan(int.Parse(Row1[columnIndex].ToString().Split(':')[0]), int.Parse(Row1[columnIndex].ToString().Split(':')[1]), 0);
                    TimeSpan CellValue2 = new TimeSpan(int.Parse(Row2[columnIndex].ToString().Split(':')[0]), int.Parse(Row2[columnIndex].ToString().Split(':')[1]), 0);
                    CompareResult = TimeSpan.Compare(CellValue1, CellValue2);
    
                }
    
                return CompareResult * sortOrderModifier;
    
    
            }
    
            public int Compare(object x, object y)
            {
                try
                {
    
                    DataGridViewRow Row1 = (DataGridViewRow)x;
                    DataGridViewRow Row2 = (DataGridViewRow)y;
                    int CompareResult = 0;
    
                    if (Row1.Index >= 0 && Row2.Index >= 0 && !String.IsNullOrEmpty(Row1.Cells[columnIndex].Value.ToString()) && !String.IsNullOrEmpty(Row2.Cells[columnIndex].Value.ToString()))
                    {
    
                        TimeSpan CellValue1 = new TimeSpan(int.Parse(Row1.Cells[columnIndex].Value.ToString().Split(':')[0]), int.Parse(Row1.Cells[columnIndex].Value.ToString().Split(':')[1]), 0);
                        TimeSpan CellValue2 = new TimeSpan(int.Parse(Row2.Cells[columnIndex].Value.ToString().Split(':')[0]), int.Parse(Row2.Cells[columnIndex].Value.ToString().Split(':')[1]), 0);
                        CompareResult = TimeSpan.Compare(CellValue1, CellValue2);
    
    
                    }
                    return CompareResult * sortOrderModifier;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    
            }
    
            public override string ToString()
            {
                return stringValue;
            }
    
            public int CompareTo(object obj)
            {
                var val1 = this.ToString();
                var val2 = obj.ToString();
                var CompareResult = 0;
                if (String.IsNullOrEmpty(val1) && String.IsNullOrEmpty(val2))
                {
                    CompareResult = 0;
    
    
                }
                else if (String.IsNullOrEmpty(val1))
                {
                    CompareResult = -1;
                }
                else if (String.IsNullOrEmpty(val2))
                {
                    CompareResult = 1;//1 , -1
                }
                else
                {
                    TimeSpan CellValue1 = new TimeSpan(int.Parse(val1.Split(':')[0]), int.Parse(val1.Split(':')[1]), 0);
                    TimeSpan CellValue2 = new TimeSpan(int.Parse(val2.Split(':')[0]), int.Parse(val2.Split(':')[1]), 0);
                    CompareResult = TimeSpan.Compare(CellValue1, CellValue2);
    
                }
    
                return CompareResult * sortOrderModifier;
                // throw new NotImplementedException();
            }
    
           
        }
     
