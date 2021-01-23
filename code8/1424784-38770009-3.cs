    public virtual Task ExecuteAsync(ActionContext actionContext, IView view, ViewResult viewResult)
    {
        if (actionContext == null)
        {
            throw new ArgumentNullException(nameof(actionContext));
        }
        if (view == null)
        {
            throw new ArgumentNullException(nameof(view));
        }
        if (viewResult == null)
        {
            throw new ArgumentNullException(nameof(viewResult));
        }
        Logger.ViewResultExecuting(view);
        return ExecuteAsync(
                actionContext,
                view,
                viewResult.ViewData,
                viewResult.TempData,
                viewResult.ContentType,
                viewResult.StatusCode);
        }
    }
