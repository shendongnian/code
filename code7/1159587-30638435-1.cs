    public abstract class MyAutoQueryServiceBase : AutoQueryServiceBase
    {
        public override object Exec<From>(IQuery<From> dto)
        {
            var q = AutoQuery.CreateQuery(dto, Request);
            var session = base.SessionAs<CustomUserSession>();
            q.And("CustomerId = {0}", session.CustomerId);
            return AutoQuery.Execute(dto, q);
        }
        public override object Exec<From, Into>(IQuery<From, Into> dto)
        {
            var q = AutoQuery.CreateQuery(dto, Request);
            var session = base.SessionAs<CustomUserSession>();
            q.And("CustomerId = {0}", session.CustomerId);
            return AutoQuery.Execute(dto, q);
        }
    }
