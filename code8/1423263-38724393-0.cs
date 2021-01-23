    protected void generateReport(object sender, EventArgs e)
    {
        BindReportData();
    }
    private void BindReportData()
    {
        int[] selectedLocations = getLocations();
        int[] selectedItemTypes = getItems();
        DateTime from = Convert.ToDateTime(fromDateBox.Text);
        DateTime to = Convert.ToDateTime(toDateBox.Text);
        if (!allButton.Checked)
        {
            Int32 statusID;
            if (openButton.Checked)
            {
                statusID = 1;
            }
            else
            {
                statusID = 2;
            }
            using (ticketModel dbContext = new ticketModel())
            {
                allTicketGrid.DataSource = dbContext.TICKETs.Where(t => t.STATUS_TYPE.STATUS_TYPE_ID == statusID && selectedLocations.Contains(t.PROPERTY_ID) && selectedItemTypes.Contains(t.ITEM_TYPE_ID) && t.OPEN_STATUS.UPDATED_DATE >= from && t.OPEN_STATUS.UPDATED_DATE <= to).ToList();
                allTicketGrid.DataBind();
            }
        }
        else
        {
            using (ticketModel dbContext = new ticketModel())
            {
                allTicketGrid.DataSource = dbContext.TICKETs.Where(t => selectedLocations.Contains(t.PROPERTY_ID) && selectedItemTypes.Contains(t.ITEM_TYPE_ID) && t.OPEN_STATUS.UPDATED_DATE >= from && t.OPEN_STATUS.UPDATED_DATE <= to).ToList();
                allTicketGrid.DataBind();
            }
        }
    }
