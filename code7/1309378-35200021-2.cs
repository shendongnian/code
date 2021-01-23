        private void btnSearch_Click(object sender, EventArgs e)
                {
        
                    //This creates the String Publisher which grabs the information from the combo box on the form.
                    //Select and Dataconnection are also defined here.
                    
                        //here you can check if the textbox.Text is empty and if it is use the % char to match anything
                        string Department = String.IsNullOrEmpty(txtDepartment.Text)? "%" : txtDepartment.Text;
                        string Start_Date = String.IsNullOrEmpty(txtStart.Text)? "%": txtStart.Text;
                        string End_Date = String.IsNullOrEmpty(txtEnd.Text)? "%" : txtEnd.Text;
                        string Anatomy = String.IsNullOrEmpty(txtAnatomy.Text)? "%":txtAnatomy.Text;
                        string RFR = String.IsNullOrEmpty(cmbRFR.Text)? "%" : cmbRFR.Text;
                        string Comment = String.IsNullOrEmpty(txtComment.Text)? "%":txtComment.Text;
        
                //the query could look like this:
                       string Select = "SELECT * FROM tblReject_test WHERE department_id LIKE '" +Department +"'" + "AND body_part_examined like'" + Anatomy +"'"+"AND study_date like'"+ Start_Date +"'";//and so on
               //rest of the code
        }
