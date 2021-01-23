        public decimal GetCartAmount(int cartId)
        {
    
            var returnCode = new SqlParameter("@ReturnCode", SqlDbType.Bit) { Direction = ParameterDirection.Output };
    
            object[] parameters =
            {
                new SqlParameter(@"CartId", SqlDbType.BigInt) {Value = cartId}
                , returnCode
            };
    
            string command = string.Format("exec @ReturnCode = dbo.fn_CartAmount @CartId");
            Database.ExecuteSqlCommand(command, parameters);
    
    
            return (decimal)returnCode.Value;
        }
