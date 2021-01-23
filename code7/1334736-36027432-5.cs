    [RoutePrefix(@"api/Test")]
    public class DerivedController : GenericController<ConcreteEntity> {
        public DerivedController (IGenericModel<ConcreteEntity> model) : base(model) {
        }
        public override IHttpActionResult Post(ConcreteEntity entity) {
            //New Post Functionality Here
        }
    }
