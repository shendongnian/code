    public class BatchInsertController : ApiController
    {
        DbContext context;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.context = new DbContext();
        }
        [HttpPost]
        public async Task<bool> BatchInsert(List<Entity> entities)
        {
            try
            {
                this.context.Entities.AddRange(entities);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Error: " + ex);
                return false;
            }
        }
    
    }
