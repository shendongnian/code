    partial class klpm_user
    {
        public UserModel GUserModel
        {
            get 
            { 
                return new UserModel{
                   UserID = user.UserID,
                   ....};
            }
        }
    }
