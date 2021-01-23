    public partial class UserDefinedFunctions
    {
        [SqlFunction(DataAccess=DataAccessKind.None, IsDeterministic=true, IsPrecise=true, SystemDataAccess=SystemDataAccessKind.None)]
        [return: SqlFacet(MaxSize=16)]
        public static  SqlBinary TryParseIPAddress([SqlFacet(MaxSize=40)] SqlString iPAddress)
        {
            if (iPAddress.IsNull) return SqlBinary.Null;
            try
            {
                var address = IPAddress.Parse(iPAddress.Value);
                return new SqlBinary(address.GetAddressBytes());
            }
            catch
            {
                return SqlBinary.Null;
            }
        }
    }
