    bool status = CheckStatus();
            if (status)
            {
                submitmodMark1st.Visible = true;
            }
            else
            {
                //All elements for grade submission made invisible- admin will be unable to change the grade
                //TB.Visible = false;
                changedFlagVal.Text = "The grade for this module has already been changed for the selected student";
                changedFlagVal.Visible = true;
                changedFlagVal.ForeColor = System.Drawing.Color.Red;
                submitmodMark1st.Visible = false;
            }
