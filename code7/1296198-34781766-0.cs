    public void ProcessGrid(DataGridView gridView, Action<Well, DateTime, DataGridViewCell> operaiton)
            {
                if (gridView != null)
                {
                    for (int i = 0; i < gridView.Rows.Count - 1; i++)        //Ignore last row - it is blank for user added rows.
                    {
                        DataGridViewRow priorityRow = gridView.Rows[i];
                        DateTime productionDay = Convert.ToDateTime(priorityRow.Cells[0].Value);
                         if (!storedDates.Contains(productionDay)) storedDates.Add(productionDay);
                        for (int j = 1; j < priorityRow.Cells.Count; j++)
                        {
                            Well well = (Well)gridView.Columns[j].Tag;
                              if (_WellList.ContainsValue(well))
                            {
                               // This is where the delegate will fire.
                                operaiton(well, productionDay, priorityRow.Cells[j]);
                            }
                        }
                    }
                }
            }
