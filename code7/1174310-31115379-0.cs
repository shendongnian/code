    using (var cmd = connection.CreateCommand())
    {
        cmd.CommandType = CommandType.Text;
        cmd.BindByName = true;
        cmd.CommandText =
            "INSERT INTO STORAGE (STRG_ID, APPL_ID, TASK_ID, PARM_TYPE_ID, PARM_VAL_TXT,APPL_ITEM_TXT) " +
            " VALUES (STRG_ID_SEQ.nextval, :parmApplId, :parmTaskId, :parmTypeId, :ParmValTxt, :parmBlob)";
        cmd.Parameters.Add("parmApplId", appId);
        cmd.Parameters.Add("parmTaskId", taskId);
        cmd.Parameters.Add("parmTypeId", parmTypeId);
        cmd.Parameters.Add("ParmValTxt", parmValue);
        OracleParameter param = cmd.Parameters.Add("parmBlob", OracleDbType.Blob); 
        string tim = "this is some very large string 42k characters";
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(tim);
        param.Value = bytes; 
        cmd.ExecuteNonQuery();
    }
