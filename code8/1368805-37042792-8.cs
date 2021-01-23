        private void CBBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
        //The SelectedIndexChanged event
        
            int SelectedBranch = CBBranchName.SelectedIndex;
            BranchItem Selected = CBBranchName.Items[SelectedBranch] as BranchItem;
            if (Selected!=null)
            {
               BranchSelectedID = Selected.ID;
            }
            DGVEmployee.Rows.Clear();
           var EmployeeData = from E in db.EmployeeTbls
                               join B in db.BranchTbls
                               on E.Branch_ID equals B.Branch_ID
                               where E.Branch_ID == BranchSelectedID
                               select new { E.Employee_ID, E.Employee_Name, E.Hire_Date, B.Branch_Name };
            if (EmployeeData != null)
            {
                foreach (var item in EmployeeData)
                {
                  DataGridViewRow row = new DataGridViewRow();
                  row.CreateCells(DGVEmployee);
                    row.Cells[0].Value = item.Employee_ID;
                    row.Cells[1].Value = item.Employee_Name;
                    row.Cells[2].Value = item.Hire_Date;
                    row.Cells[3].Value = item.Branch_Name;
                    DGVEmployee.Rows.Add(row);
                }
            }
        }
