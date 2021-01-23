        private void BindDataGrid()
        {
            GenerateReportsButton.Enabled = true;
            reportsTable.Rows.Clear();
            TableHeaderRow headerrow = new TableHeaderRow();
            TableHeaderCell pnumberheader = new TableHeaderCell();
            TableHeaderCell templateheader = new TableHeaderCell();
            TableHeaderCell fileFormatHeader = new TableHeaderCell();
            pnumberheader.Text = ResourceHelper.LoadResource(ResourceName.ProjectnumberTableString);
            templateheader.Text = ResourceHelper.LoadResource(ResourceName.TemplateString);
            fileFormatHeader.Text = ResourceHelper.LoadResource(ResourceName.FileFormatString);
            headerrow.Cells.Add(pnumberheader);
            headerrow.Cells.Add(templateheader);
            headerrow.Cells.Add(fileFormatHeader);
            reportsTable.Rows.Add(headerrow);
            if (ddlYear.SelectedItem == null || ddlMonth.SelectedItem == null)
            {
                int index = reportsTable.Rows.Add(new TableRow());
                TableCell cell = new TableCell();
                cell.ColumnSpan = 3;
                cell.Text = ResourceHelper.LoadResource(ResourceName.NoListItemsForMonthYear);
                reportsTable.Rows[index].Cells.Add(cell);
                GenerateReportsButton.Enabled = false;
                return;
            }
            //Get items here
            if (items.Count == 0)
            {
                int index = reportsTable.Rows.Add(new TableRow());
                TableCell cell = new TableCell();
                cell.ColumnSpan = 3;
                cell.Text = ResourceHelper.LoadResource(ResourceName.NoListItemsForMonthYear);
                reportsTable.Rows[index].Cells.Add(cell);
                GenerateReportsButton.Enabled = false;
                return;
            }
            else
                InsertRowIntoProjectTable("Intern", "Intern");
            List<string> processedReports = new List<string>();
            foreach(SPListItem item in items)
            {
                if (item[Variables.projectNumberField].ToString() != "Intern" && !processedReports.Contains(item[Variables.activityProject].ToString()))
                {
                    InsertRowIntoProjectTable(item[Variables.activityProject].ToString(), item.ID.ToString());
                    processedReports.Add(item[Variables.activityProject].ToString());
                }
            }
        }
