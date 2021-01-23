    _cmdDueAtDock.Parameters.Add(new OleDbParameter() {
        ParameterName = "order_no_", OleDbType = OleDbType.VarChar,
        Direction = ParameterDirection.Input, Value = _order_line.ORDER_NO });
    _cmdDueAtDock.Parameters.Add(new OleDbParameter() {
        ParameterName = "line_no_", OleDbType = OleDbType.VarChar,
        Direction = ParameterDirection.Input, Value = _order_line.LINE_NO });
    _cmdDueAtDock.Parameters.Add(new OleDbParameter() {
        ParameterName = "release_no_", OleDbType = OleDbType.VarChar,
        Direction = ParameterDirection.Input, Value = _order_line.RELEASE_NO });
    _cmdDueAtDock.Parameters.Add(new OleDbParameter() {
        ParameterName = "rv_", OleDbType = OleDbType.Decimal,
        Direction = ParameterDirection.Output });   /// <- change is here
    try
    {
        _cmdDueAtDock.ExecuteNonQuery();
        decimal dueAtDock = Convert.ToDecimal(_cmdDueAtDock.Parameters[3].Value);
    }
    catch (Exception ex)
    {
        decimal dueAtDock = 0;
    }
