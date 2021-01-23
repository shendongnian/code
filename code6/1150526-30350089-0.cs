    public abstract class AbstractController<TEntity, TId> : Controller
    {
        // irrelevant stuff omitted
        public ActionResult Edit(TEntity id);
    }
