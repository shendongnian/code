    if (!includeClosedSubTasks)
    {
        // TODO get session here somehow as you do normally
        var session = NHSession.GetCurrent();
        // tasks that aren't completed / closed / cancelled
        var qryString = @"SELECT st
                        FROM SubTask st
                        WHERE st.ParentTask.ParentProject.ParentClient = :clientObj
                        AND st.ParentTaskCategory.VisibleToClient = 1 "
                        + filter + // more ands
                        @" AND st.ParentTaskStatus.ID NOT IN (3, 4, 8)
                        OR st.RaisedByClientID = :clientIDObj
                        ORDER BY st.CreateDateTime";
        var query = session.CreateSQLQuery(qryString)
            .SetParameter("clientObj", client)
            .SetParameter("clientIDObj", client.ID);
        // return query or whatever you need to do
    }
