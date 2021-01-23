    public class GenericActionModel
    {
        private bool v1;
        private string v2;
        private string v3;
        private string v4;
        private bool v5;
        protected GenericActionModel() {}
        public GenericActionModel(bool v1, string v2, string v3, string v4, bool v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }
    }
    public class ActionResult
    {
        private GenericActionModel responseModel;
        private string v;
        public ActionResult(string v, GenericActionModel responseModel)
        {
            this.v = v;
            this.responseModel = responseModel;
        }
    }
    public class PasswordChangeModel : GenericActionModel
    {
        public object PasswordResetHash
        {
            get;
            set;
        }
    }
    public interface IUserManager
    {
        Response IsValidPasswordResetHash(string passwordResetHash);
    }
