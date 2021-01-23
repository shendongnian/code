    public abstract class AbstractLazyFieldHolder
    {
        protected AbstractLazyFieldHolder()
        {
            LazyFields.BuildUp(this); // ensures fields are populated.
        }
    }
