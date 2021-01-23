    public class CustomerMapper : ReportTemplate
    {
        ...
        public List<IReportRelation<Customer, Client>> ReportRelations
        {
            return new List<IReportRelation<Customer, Client>>
            { 
                new ReportRelation<Customer, Client>
                {
                    LocalMapper = this.customerMapper,
                    ForeignMapper = this.clientMapper,
                    ForeignColumn = customerMapper.GetReportColumn(x => x.ClientId),
                    LocalColumn = clientMapper.GetReportColumn(x => x.Id)
                }
            };
        }
    }
