    
    public abstract class GenericController<TEntity> : ApiController where TEntity : class {
    
        [HttpPost, Route]
        public virtual IHttpActionResult Post(TEntity entity) {
            TEntity newEntity = _model.Create(entity);
            String urlLink = $"{Request.RequestUri}{RequestContext.VirtualPathRoot}{((IGenericEntity)newEntity).ID}";
            return Created(urlLink, newEntity);
        }
    }
