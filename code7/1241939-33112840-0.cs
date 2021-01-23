            protected void ViewButton_Click(object sender, EventArgs e) {
              List < string > selectedSubjects = new List < string > ();
              foreach(GridViewRow gvr in dgvUsers.Rows) {
                CheckBox chk = (CheckBox) gvr.Cells[1].FindControl("CheckBox1");
                if (chk.Checked) {
                  selectedSubjects.Add(chk.Text);
                }
              }
              if (selectedSubjects.Count > 0) {
                gvSelected.DataSource = selectedSubjects;
                gvSelected.DataBind();
              }
            }
