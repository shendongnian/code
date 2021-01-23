    protected void btnUpdae_Click(object sender, EventArgs e)
        {
                int rowIndex = 0;
                StringCollection sc = new StringCollection();
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values
                            TextBox box1 = (TextBox)gvMarks.Rows[rowIndex].Cells[1].FindControl("txt1");
                            TextBox box2 = (TextBox)gvMarks.Rows[rowIndex].Cells[2].FindControl("txt2");
                            TextBox box3 = (TextBox)gvMarks.Rows[rowIndex].Cells[3].FindControl("txt3");
        		            TextBox box4 = (TextBox)gvMarks.Rows[rowIndex].Cells[3].FindControl("txt4");
        		            TextBox box5 = (TextBox)gvMarks.Rows[rowIndex].Cells[3].FindControl("txt5");
        		            TextBox box6 = (TextBox)gvMarks.Rows[rowIndex].Cells[3].FindControl("txt6");
         
                            //get the values from the TextBoxes
                            //then add it to the collections with a comma "," as the delimited values
                            sc.Add(box1.Text + "," + box2.Text + "," + box3.Text+ "," + box4.Text + "," + box5.Text+ "," + box6.Text);
                            rowIndex++;
                        }
                        //Call the method for executing inserts or update
                    }
                }
        }
