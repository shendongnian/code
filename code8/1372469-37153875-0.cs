    class Program
    {
        static void Main(string[] args)
        {
            List<IBaseEntity> entities=new List<IBaseEntity>();
            IBaseEntity acct=new Account() { AcctNum="1001-Q" };
            entities.Add(acct);
            IBaseEntity cust=new Customer() { FullName="Draco Malfoy" };
            entities.Add(cust);
            List<BaseResponse> responces=new List<BaseResponse>();
            responces.Add(cust.GetResponce());
            responces.Add(acct.GetResponce());
            foreach (var item in responces.OfType<AddCustomerResponse>())
            {
                Console.WriteLine(item.FullName);
            }
            foreach (var item in responces.OfType<AddAccountResponse>())
            {
                Console.WriteLine(item.AcctNum);
            }
        }
    }
