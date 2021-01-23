    public int Delete(string query, object[] values, IType[] types)
    {
        using (new SessionIdLoggingContext(SessionId))
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException("query", "attempt to perform delete-by-query with null query");
            }
            CheckAndUpdateSessionStatus();
            if (log.IsDebugEnabled)
            {
                log.Debug("delete: " + query);
                if (values.Length != 0)
                {
                    log.Debug("parameters: " + StringHelper.ToString(values));
                }
            }
            IList list = Find(query, values, types);
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                Delete(list[i]);
            }
            return count;
        }
    }
