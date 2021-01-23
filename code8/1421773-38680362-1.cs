    var rows = Database.ExecuteQuery(query,
                new QueryParameter("accountId", accountId),
                new QueryParameter("orig_lat", latitude),
                new QueryParameter("orig_lon", longitude),
                new QueryParameter("dist", 1000 * rangeInKM),
                new QueryParameter("limit", limit),
                new QueryParameter("page", page - 1));
