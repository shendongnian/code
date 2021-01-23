    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }
    public class AddAccountResponse : BaseResponse
    {
        public string AcctNum { get; set; }
    }
    public class AddCustomerResponse : BaseResponse
    {
        public string FullName { get; set; }
    }
    public interface IBaseEntity
    {
        BaseResponse GetResponce();
    }
    public class Customer : IBaseEntity
    {
        public string FullName { get; set; }
        public AddCustomerResponse GetResponce()
        {
            return new AddCustomerResponse()
            {
                FullName=this.FullName
            };
        }
    }
    public class Account : IBaseEntity
    {
        public string AcctNum { get; set; }
        public AddAccountResponse GetResponce()
        {
            return new AddAccountResponse()
            {
                AcctNum=this.AcctNum
            };
        }
    }
