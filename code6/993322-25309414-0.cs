    class Class6
    {
        public object GetTranslations() { return null; }
        public object GetEAAnalysisData() { return null; }
        public void DoStuff()
        {
            CustomerViewRequest cvRequest = new CustomerViewRequest();
            cvRequest.Translations = GetTranslations(); // generic to Request
            cvRequest.CustomerViewAsOfDate = new DateTime(2014, 1, 1); // specific to CustomerViewRequest
            CustomerViewResponse cvResponse = ViewCreator.CreateViewResponse<CustomerViewResponse>(cvRequest);
            Console.WriteLine(cvResponse.ViewResponseCreatedSuccessfully); // generic to Response
            Console.WriteLine(cvResponse.SomeCustomerViewSpecificProperty); // specific to CustomerViewResponse
            BKLedgerViewRequest bkRequest = new BKLedgerViewRequest();
            bkRequest.Translations = GetTranslations(); // generic to Request
            bkRequest.EAAnalysisData = GetEAAnalysisData(); // specific to BKLedgerViewRequest
            BKLedgerViewResponse bkResponse = ViewCreator.CreateViewResponse<BKLedgerViewResponse>(bkRequest);
            Console.WriteLine(bkResponse.ViewResponseCreatedSuccessfully); // generic to Response
            Console.WriteLine(bkResponse.SomeBKLedgerViewSpecificProperty); // specific to BKLedgerViewResponse
        }
    }
    class ViewRequest
    {
        public object Translations { get; set; }
    }
    class ViewResponse
    {
        public bool ViewResponseCreatedSuccessfully { get; set; }
    }
    class CustomerViewRequest : ViewRequest
    {
        public DateTime CustomerViewAsOfDate { get; set; }
    }
    class CustomerViewResponse : ViewResponse
    {
        public string SomeCustomerViewSpecificProperty { get; set; }
    }
    static class ViewCreator
    {
        public static T CreateViewResponse<T>(ViewRequest request)
            where T : ViewResponse, new()
        {
            return new T();
        }
    }
    class BKLedgerViewResponse : ViewResponse
    {
        public int SomeBKLedgerViewSpecificProperty { get; set; }
    }
    class BKLedgerViewRequest : ViewRequest
    {
        public object EAAnalysisData { get; set; }
    }
