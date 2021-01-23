            try
            {
                if (MouseButtons != 0) return;
                if (_celWasEndEdit != null && dataGridView1.CurrentCell != null)
                {
                    // if we are currently in the next line of last edit cell
                    if (dataGridView1.CurrentCell.RowIndex == _celWasEndEdit.RowIndex + 1 &&
                        dataGridView1.CurrentCell.ColumnIndex == _celWasEndEdit.ColumnIndex)
                    {
                        int iColNew;
                        int iRowNew = 0;
                        if (_celWasEndEdit.ColumnIndex >= dataGridView1.ColumnCount - 1)
                        {
                            iColNew = 0;
                            iRowNew = dataGridView1.CurrentCell.RowIndex;
                        }
                        else
                        {
                            iColNew = _celWasEndEdit.ColumnIndex + 1;
                            iRowNew = _celWasEndEdit.RowIndex;
                        }
                        dataGridView1.CurrentCell = dataGridView1[iColNew, iRowNew];
                    }
                }
                _celWasEndEdit = null;
            }
            catch(Exception)
            {
                //Invisible Column Exception
            }
        }
