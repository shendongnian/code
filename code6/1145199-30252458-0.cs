    public class Customer
    {
        public Customer(OracleConnector oracle, WebSerivceConnector webservice, EntityConnector entity)
        {
            this.oracle = oracle;
            this.webservice = webservice;
            this.entity = entity;
        }
    
        public void Fetch()
        {
            // fetch data from oracle, webservice, and entity.
            this.Name = oracle.GetCustomerName();
        }
    }
