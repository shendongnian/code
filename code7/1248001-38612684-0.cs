    public class UserStore : IUserStore<User>, IUserLoginStore<User>, IUserPasswordStore<User>, IUserRoleStore<User>
    {
        private readonly string connectionString;
        public UserStore()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }      
        /// <summary>
        /// Returns User tables information, based on parameter type userId/Username will be equated in where condition
        /// </summary>
        /// <param name="userId">userId or Username can be passed</param>
        /// <returns></returns>
        public virtual Task<User> FindByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId.ToString()))
                throw new ArgumentNullException("userId", string.Format("'{0}' is not a valid format.", new { userId }));
            return Task.Factory.StartNew(() =>
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);
                using (SqlConnection connection = new SqlConnection(connectionString))
                    return connection.Query<User>("spUsers_GetUser", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
            });
        }
