        public T ExecuteScalar<T>(SqlCommand cmd, params SqlParameter[] Params)
        {
            try
            {
                if (Transaction != null && Transaction != default(SqlTransaction))
                    cmd.Transaction = Transaction;
                else
                    cmd.Connection = SqlConn;
                if (Params != null && Params.Length > 0)
                {
                    foreach (var param in Params)
                        cmd.Parameters.Add(param);
                }
                Open();
                var retVal = cmd.ExecuteScalar();
                if (retVal is T)
                    return (T)retVal;
                else if (retVal == DBNull.Value)
                    return default(T);
                else
                    throw new Exception("Object returned was of the wrong type.");
            }
            finally
            {
                Close();
            }
        }
