    DateTime? dtStartFrom = null;
    SqlParameter sqlDateparam = new SqlParameter("@dtStartFrom", SqlDbType.DateTime);
    sqlDateparam.IsNullable = true;
    if (dtStartFrom.HasValue)
        sqlDateparam.Value = dtStartFrom.Value;
    else
        sqlDateparam.Value = DBNull.Value
    
    var result = _context.Database.SqlQuery<DamageEventsDTL>("SPDamageEventsDTL  @dtStartFrom", sqlDateparam).ToList();
