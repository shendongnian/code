    if (copyStylesFromRow > 0)
                    {
                        var cseS = new CellsStoreEnumerator<int>(_styles, copyStylesFromRow, 0, copyStylesFromRow, ExcelPackage.MaxColumns); //Fixes issue 15068 , 15090
                        while(cseS.Next())
                        {
                            for (var r = 0; r < rows; r++)
                            {
                                _styles.SetValue(rowFrom + r, cseS.Column, cseS.Value);
                            }
                        }
                    }
