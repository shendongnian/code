        foreach (string emailAddy in userEmailList.Keys)
        {
            StringBuilder sbDue = new StringBuilder();
            StringBuilder sbNotDue = new StringBuilder();
            sbDue.Append("<html><head></head><body>");
            sbDue.Append("<h2>Tasks Due</h2><ul>");
            foreach (DataRow row in userEmailList[emailAddy])
            {
                if (!String.IsNullOrEmpty(row["dueDate"].ToString()))
                {
                    dueDate = Convert.ToDateTime(row["dueDate"]).ToShortDateString();
                    sbDue.AppendFormat("<li><strong>{0}</strong> - {1}</li>", dueDate, row["details"].ToString());
                }
                else
                     sbNotDue.AppendFormat("<li>{0}</li>", row["details"].ToString());
            }
            if(sbNotDue.Length > 0)
            {
               sbNotDue.Insert("<h2>No Due Date</h2><ul>");
               sbDue.Append(sbNotDue.ToString());
            } 
            sbDue.Append("</ul></body><html>");
        }
