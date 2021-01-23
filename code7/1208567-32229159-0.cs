        protected void btnNext_Click1(object sender, EventArgs e)
        {
            DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter eobj = new DAL.TicketsDataSetTableAdapters.TicketDetailsTableAdapter();
            DataTable dt = new DataTable();
            if (txtNextStep.Tag == null)//Pick first update.
                dt = eobj.GetTicketFirstUpdate(txtSupportRef.Text);
            else//Getting next ticket update for the ticket based on current displaying value
                dt = eobj.GetNextTicketUpdate(txtSupportRef.Text, (string)txtNextStep.Tag);
            if (dt.Rows.Count != 0)
            {
                txtNextStep.Text = dt.Rows[0]["NextStep"].ToString();
                txtNextStep.Tag = dt.Rows[0]["Id"].ToString();
            }
        }
