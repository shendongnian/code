        private void searchGridView(string searchTerm)
        {
            int rowIndexParent = -1;
            int cellIndexParent = -1;
            int rowIndexChild = -1;
            int cellIndexChild = -1;
            bool searchTermFound = false;
            //loop all rows in parent grid
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //remove this if you want the last match displayed as found, not the first
                if (searchTermFound == false)
                {
                    //loop all cells in parent grid
                    for (int j = 0; j < GridView1.Columns.Count; j++)
                    {
                        string cellContent = GridView1.Rows[i].Cells[j].Text;
                        if (cellContent.ToLower() == searchTerm.ToLower())
                        {
                            rowIndexParent = i;
                            cellIndexParent = j;
                            searchTermFound = true;
                            break;
                        }
                    }
                    //find the nested grid and cast it
                    GridView gv = GridView1.Rows[i].FindControl("GridView2") as GridView;
                    //loop all rows in child grid
                    for (int ii = 0; ii < gv.Rows.Count; ii++)
                    {
                        //loop all cells in child grid
                        for (int jj = 0; jj < gv.Columns.Count; jj++)
                        {
                            string cellContent = gv.Rows[ii].Cells[jj].Text;
                            if (cellContent.ToLower() == searchTerm.ToLower())
                            {
                                rowIndexParent = i;
                                rowIndexChild = ii;
                                cellIndexChild = jj;
                                searchTermFound = true;
                                break;
                            }
                        }
                    }
                }
            }
            //cellIndexParent > -1 means searchTerm is found in parent grid, not child
            if (searchTermFound == true && cellIndexParent > -1)
            {
                Response.Write("Searchterm \"" + searchTerm + "\" found in parent grid: row " + rowIndexParent + ", column " + cellIndexParent + ".");
            }
            else if (searchTermFound == true)
            {
                Response.Write("Searchterm \"" + searchTerm + "\" found in child grid: row " + rowIndexChild + ", column " + cellIndexChild + ", parent row " + rowIndexParent + ".");
            }
            else
            {
                Response.Write("Searchterm \"" + searchTerm + "\" not found.");
            }
        }
