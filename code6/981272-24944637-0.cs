    ((from query in dtx.WebQueries
        join wt in dtx.WebTasks on wt.TaskReportCategory equals query.QueryCategory
        where wt.TaskKey == taskKey
        select new {query, thekey = query.QueryKey}).OrderBy(query => query.QueryTitle)
        where!(
        from qry in dtx.WebQueries
        join qg in dtx.WebQueryGroups on qry.QueryKey equals qg.QueryKey
        join wp in dtx.WebPermissions on qg.QueryGroupNameKey equals wp.TaskGroupNameKey
        join wugn in dtx.WebUserGroupNames on wp.UserGroupNameKey equals wugn.UserGroupNameKey
        join wug in dtx.WebUserGroups on wugn.UserGroupNameKey equals wug.UserGroupNameKey
        join wt in dtx.WebTasks on wt.TaskReportCategory equals qry.QueryCategory
        where wp.ResourceKey == 4 && wt.TaskKey == taskKey && wug.UserKey == userKey
        select qry.QueryKey).Contains(thekey));
