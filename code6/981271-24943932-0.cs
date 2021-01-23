    select new { query, key = query.QueryKey}).OrderBy(x => x.query.QueryTitle)
    .Where(q => !(from qry in dtx.WebQueries join 
            qg in dtx.WebQueryGroups on qry.QueryKey equals qg.QueryKey join
            wp in dtx.WebPermissions on qg.QueryGroupNameKey equals wp.TaskGroupNameKey join 
            wugn in dtx.WebUserGroupNames on wp.UserGroupNameKey equals wugn.UserGroupNameKey join
            wug in dtx.WebUserGroups on wugn.UserGroupNameKey equals wug.UserGroupNameKey join 
            wt in dtx.WebTasks on qry.QueryCategory equals wt.TaskReportCategory
            where wp.ResourceKey == 4 
            && wt.TaskKey == taskKey 
            && wug.UserKey == userKey
            select qry.QueryKey).Contains(q.key))
