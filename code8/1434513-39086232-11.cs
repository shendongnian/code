    public class OrganizationServiceBuilder : DLaB.Xrm.Test.Builders.OrganizationServiceBuilderBase<OrganizationServiceBuilder>
    {
        protected override OrganizationServiceBuilder This
        {
            get { return this; }
        }
        #region Constructors
        public OrganizationServiceBuilder() : this(TestBase.GetOrganizationService()) {}
        public OrganizationServiceBuilder(IOrganizationService service) : base(service) { WithSalesOrderNumbersDefaulted(); }
        #endregion Constructors
        #region Fluent Methods
        private static int _salesNumber = 1;
        public OrganizationServiceBuilder WithSalesOrderNumbersDefaulted() {
            WithFakeCreate((s, e) =>
            {
                if (e.LogicalName == SalesOrder.EntityLogicalName && e.GetAttributeValue<string>(SalesOrder.Fields.OrderNumber) == null)
                {
                    _salesNumber++; //Use Interlocking if thread safe is required 
                    e[SalesOrder.Fields.OrderNumber] = _salesNumber;
                }
                return s.Create(e);
            });
            return this;
        }
        #endregion Fluent Methods
    }
