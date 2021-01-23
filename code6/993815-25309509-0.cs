    public string GenerateWhereClause()
    {
        List<String> conditions = new List<String>();
        
        conditions.Add("(CT.ACTIVESTATUS = 0)");
        
        if (ddlTaskName.SelectedIndex > 0)
        {
            string strText = ddlTaskName.SelectedItem.Text;
            conditions.Add(String.Format("(CT.ATTR2739 = '{0}')", strText));
        }
        
        if (ddlService.SelectedIndex > 0)
        {
            string strText = ddlService.SelectedItem.Text;
            conditions.Add(String.Format("(CT.ATTR2846 = '{0}')", strText));
        }
        
        if (ddlStatus.SelectedIndex > 0)
        {
            string strText = ddlStatus.SelectedItem.Text;
            conditions.Add(String.Format("(CT.ATTR2812 = '{0}')", strText));
        }
        
        if (ddlDueDate.SelectedIndex > 0)
        {
            string strText = ddlDueDate.SelectedItem.Text;
            conditions.Add(String.Format("(CONVERT(VARCHAR(14), CT.ATTR2752, 110) = '{0}')", strText));
        }
        
        if (ddlOwner.SelectedIndex > 0)
        {
            string strText = ddlOwner.SelectedItem.Text;
            conditions.Add(String.Format("(UA.REALNAME = '{0}')", strText));
        }
        
        if (ddlClient.SelectedIndex > 0)
        {
            string strText = ddlClient.SelectedItem.Text;
            conditions.Add(String.Format("(CT.ATTR2799 = '{0}')", strText));
        }
        // You can add additional filters here.  This isn't the cleanest way of doing it, but it's fairly quick and easy as long as you don't intend to add many more filters.
        
        string conditionsJoined = String.Join(" AND ", conditions);
        string whereClause = String.Format(" WHERE {0}", conditionsJoined);
        return whereClause;
    }
    
