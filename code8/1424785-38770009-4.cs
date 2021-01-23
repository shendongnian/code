    public virtual async Task ExecuteAsync(
            ActionContext actionContext,
            IView view,
            ViewDataDictionary viewData,
            ITempDataDictionary tempData,
            string contentType,
            int? statusCode)
    {
            if (actionContext == null)
            {
                throw new ArgumentNullException(nameof(actionContext));
            }
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }
            if (viewData == null)
            {
                viewData = new ViewDataDictionary(_modelMetadataProvider, actionContext.ModelState);
            }
            if (tempData == null)
            {
                tempData = TempDataFactory.GetTempData(actionContext.HttpContext);
            }
            var response = actionContext.HttpContext.Response;
            string resolvedContentType = null;
            Encoding resolvedContentTypeEncoding = null;
            ResponseContentTypeHelper.ResolveContentTypeAndEncoding(
                contentType,
                response.ContentType,
                DefaultContentType,
                out resolvedContentType,
                out resolvedContentTypeEncoding);
            response.ContentType = resolvedContentType;
            if (statusCode != null)
            {
                response.StatusCode = statusCode.Value;
            }
            using (var writer = WriterFactory.CreateWriter(response.Body, resolvedContentTypeEncoding))
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    viewData,
                    tempData,
                    writer,
                    ViewOptions.HtmlHelperOptions);
                DiagnosticSource.BeforeView(view, viewContext);
                await view.RenderAsync(viewContext);
                DiagnosticSource.AfterView(view, viewContext);
                // Perf: Invoke FlushAsync to ensure any buffered content is asynchronously written to the underlying
                // response asynchronously. In the absence of this line, the buffer gets synchronously written to the
                // response as part of the Dispose which has a perf impact.
                await writer.FlushAsync();
            }
    }
