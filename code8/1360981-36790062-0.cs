    void btnAdd_Click(object sender, EventArgs e)
        {
            if (tRow1.Visible && !tRow2.Visible)
            {           
                tRow2.Visible = true;
                return;
            }
            else if (tRow1.Visible && tRow2.Visible && !tRow3.Visible)
            {
                tRow3.Visible = true;
                return;
            }
            else if (tRow1.Visible && tRow2.Visible && tRow3.Visible && !tRow4.Visible)
            {
                tRow4.Visible = true;
                return;
            }
            else if (tRow1.Visible && tRow2.Visible && tRow3.Visible && tRow4.Visible && !tRow5.Visible)
            {
                tRow5.Visible = true;
                return;
            }
        }
