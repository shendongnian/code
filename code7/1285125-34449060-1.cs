    public class XmlTypeConvention : IUserTypeConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Type == typeof(XDocument));
        }
    
        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<NHibernate.Type.XDocType>();
        }
    } 
