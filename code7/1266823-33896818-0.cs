    protected override void OnException(ExceptionContext filterContext)
    {
        var exception = filterContext.Exception;
        if (exception is System.Web.Http.HttpResponseException) // Catch HttpResponseException
        { 
            var msg = ex.Response.Content.ReadAsStringAsync().Result;
            var errorModel = JsonConvert.DeserializeObject<AcknowledgementModel>(msg);
            return new HttpStatusCodeResult(500, errorModel.errormessage);
        }
        else // catch (Exception ex)
        {
            return new HttpStatusCodeResult(500, ex.Message);
        }
    }
