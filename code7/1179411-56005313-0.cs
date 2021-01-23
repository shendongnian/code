csharp
public async Task<SchemePolicy> GetById(string id)
{
    return await sql.QueryFirstOrDefaultAsync<SchemePolicy>("risk.iE_GetSchemePolicyById",
        new { Id = id },
        commandType: CommandType.StoredProcedure);
}
