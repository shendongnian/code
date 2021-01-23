    public class FooController : ApiController {
        IUnitOfWork unitOfWork;
        public FooController (IUnitOfWork uow) {
            this.unitOfWork = uow;
        }
        [ResponseType(typeof(Foo))]
        public async Task<IHttpActionResult> PostFoo(Foo foo) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            //Do other stuff
            unitOfWork.Add(foo);
            await unitOfWork.SaveChangesAsync();
            //Load related entities
            unitOfWork.LoadRelatedEntity(foo, x => x.Bar);
            unitOfWork.LoadRelatedEntity(foo, x => x.Qux);
            return CreatedAtRoute("DefaultApi", new { id = foo.Id }, foo);
        }
    }
