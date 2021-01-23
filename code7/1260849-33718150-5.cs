    public partial class UserDefinedFunctions
    {
        [SqlFunction(DataAccess=DataAccessKind.None, IsDeterministic=true, IsPrecise=true, SystemDataAccess=SystemDataAccessKind.None)]
        [return: SqlFacet(MaxSize=16)]
        public static  SqlBinary TryParseIPAddress([SqlFacet(MaxSize=40)] SqlString iPAddress)
        {
            if (iPAddress.IsNull) return SqlBinary.Null;
            IPAddress address;
            if (IPAddress.TryParse(iPAddress.Value, out address))
            {
                return new SqlBinary(address.GetAddressBytes());
            }
            else return SqlBinary.Null;
        }
    }
