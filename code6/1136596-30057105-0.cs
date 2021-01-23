    using NetTopologySuite.Geometries;
    using NHibernate.Spatial.Type;
    public class PostGisPolygonUserTypeConvention : UserTypeConvention<PostGisGeometryType>
    {
        public override void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(c => c.Type == typeof(Polygon));
        }
        public override void Apply(IPropertyInstance instance)
        {
            // Have to set CustomType to be able to read/write rows using NHibernate
            instance.CustomType<PostGisGeometryType>();
            // Have to set CustomSqlType to generate correct SQL schema
            instance.CustomSqlType("geometry(Polygon)");
        }
    }
