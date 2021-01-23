    using (OleDbCommand cmd = new OleDbCommand())
    {
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE tblFormOQ SET UINumWorkers1 = ?,UINumWorkers2 = ?, UINumWorkers3 = ?, UISubjectWages = ?, UIExcessWages= ?, UITaxRate = ?, UIPrepaid = ?, UIPenalty = ?, SWTSubjectWages = ?, SWTax = ?, SWTPrepaid = ?, SWTMonth1 = ?, SWTMonth2 = ?, SWTMonth3 = ?, TriMetSubjectWages = ?, TriMetPrepaid = ?, LaneSubjectWages = ?, LanePrepaid = ?, WCHours = ?, WCPrepaid = ? WHERE BusinessID = ? and [Year] = ? and Quarter = ?";
        cmd.Parameters.AddWithValue("?", _UINumWorkers1);
        cmd.Parameters.AddWithValue("?", _UINumWorkers2);
        cmd.Parameters.AddWithValue("?", _UINumWorkers3);
        cmd.Parameters.AddWithValue("?", _UISubjectWages);
        cmd.Parameters.AddWithValue("?", _UIExcessWages);
        cmd.Parameters.AddWithValue("?", _UITaxRate);
        cmd.Parameters.AddWithValue("?", _UIPrepaid);
        cmd.Parameters.AddWithValue("?", _UIPenalty);
        cmd.Parameters.AddWithValue("?", _SWTSubjectWages);
        cmd.Parameters.AddWithValue("?", _SWTax);
        cmd.Parameters.AddWithValue("?", _SWTPrepaid);
        cmd.Parameters.AddWithValue("?", _SWTMonth1);
        cmd.Parameters.AddWithValue("?", _SWTMonth2);
        cmd.Parameters.AddWithValue("?", _SWTMonth3);
        cmd.Parameters.AddWithValue("?", _TriMetSubjectWages);
        cmd.Parameters.AddWithValue("?", _TriMetPrepaid);
        cmd.Parameters.AddWithValue("?", _LaneSubjectWages);
        cmd.Parameters.AddWithValue("?", _LanePrepaid);
        cmd.Parameters.AddWithValue("?", _WCHours);
        cmd.Parameters.AddWithValue("?", _WCPrepaid);
        cmd.Parameters.AddWithValue("?", _Businessid);
        cmd.Parameters.AddWithValue("?", _Year);
        cmd.Parameters.AddWithValue("?", _Quarter);
        cmd.ExecuteNonQuery();
    }
