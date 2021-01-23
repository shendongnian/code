    private void Frm_LocationChanged(object sender, EventArgs e)
        {
            Rectangle tabControlRectangle = new Rectangle(tabControl1.Location, tabControl1.Size);
            Rectangle childFormRectangle = new Rectangle(frm.Location, frm.Size);
            if (tabControlRectangle.IntersectsWith(childFormRectangle))
            {
                tabControl1.Visible = false;
            }
            else
            {
                tabControl1.Visible = true;
            }
        }
