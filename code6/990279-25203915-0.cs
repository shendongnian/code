    OracleConnection con = iscConnection();
    OracleCommand cmd = new OracleCommand("insert into cs_update_resolutions (task_id, cust_code, task_resolved, agent_entered) VALUES (:taskId, :custCode, :taskResolved, :getUser)", con);
    cmd.Parameters.Add(":taskId", OracleDbType.Int32).Value = actionItem.InsertTaskId;
    cmd.Parameters.Add(":custCode", OracleDbType.Int32).Value = actionItem.InsertCustCode;
    cmd.Parameters.Add(":taskResolved", OracleDbType.Varchar2).Value = actionItem.InsertResolution;
    cmd.Parameters.Add(":getUser", OracleDbType.Varchar2).Value = actionItem.InsertCurrentUser;
