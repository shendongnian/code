    private void CreateTheControlsAgain(int numberofparticipants)
        {
            
            try
            {
                ViewState["numberofparticipants"] = Convert.ToString(numberofparticipants);
                    Table tableparticipantName = new Table();
                    int rowcount = 1;
                    int columnCount = numberofparticipants;
                    for (int i = 0; i < rowcount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            TableRow row = new TableRow();
                            TableCell cell = new TableCell();
                            TextBox txtNameofParticipant = new TextBox();
                            txtNameofParticipant.ID = "txtNameofParticipant" + Convert.ToString(j);
                            cell.ID = "cell" + Convert.ToString(j);
                            cell.Controls.Add(txtNameofParticipant);
                            row.Cells.Add(cell);
                            tableparticipantName.Rows.Add(row);
                        }
                        
                    }
                    panelNameofParticipants.Controls.Add(tableparticipantName);
                }
            
            catch (Exception ex)
            {
            }
        }
