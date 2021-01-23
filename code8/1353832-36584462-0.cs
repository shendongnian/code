        routes.MapHttpRoute(
            name: "API Default",
            routeTemplate: "api/{tenantId}/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    Or the attribute-based routing, using `RoutePrefixAttribute` on your controllers:
        [RoutePrefix("api/{tenantId}/myentities")]
        public class EntityController : ApiController
        {
            [Route("")]
            public IHttpActionResult GetAllEntities(string tenantId)
            {
                //...
