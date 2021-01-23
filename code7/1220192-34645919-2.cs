        public class RikropApiControllerBase : ApiController
        {
            #region Result handling
    
            protected HttpResponseMessage Response(IOutputModel result, HttpStatusCode successStatusCode = HttpStatusCode.OK)
            {
                switch (result.Result)
                {
                    case OperationResult.AccessDenied:
                        return Request.CreateResponse(HttpStatusCode.Forbidden);
                    case OperationResult.BadRequest:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    case OperationResult.Conflict:
                        return Request.CreateResponse(HttpStatusCode.Conflict);
                    case OperationResult.NotFound:
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    case OperationResult.NotModified:
                        return Request.CreateResponse(HttpStatusCode.NotModified);
                    case OperationResult.Created:
                        return Request.CreateResponse(HttpStatusCode.Created);
                    case OperationResult.Success:
                        return Request.CreateResponse(successStatusCode);
                    default:
                        return Request.CreateResponse(HttpStatusCode.NotImplemented);
                }
            }
    
            protected HttpResponseMessage Response<TData>(IOutputDataModel<TData> result, HttpStatusCode successStatusCode = HttpStatusCode.OK)
            {
                switch (result.Result)
                {
                    case OperationResult.AccessDenied:
                        return Request.CreateResponse(HttpStatusCode.Forbidden);
                    case OperationResult.BadRequest:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    case OperationResult.Conflict:
                        return Request.CreateResponse(HttpStatusCode.Conflict);
                    case OperationResult.NotFound:
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    case OperationResult.NotModified:
                        return Request.CreateResponse(HttpStatusCode.NotModified, result.Data);
                    case OperationResult.Created:
                        return Request.CreateResponse(HttpStatusCode.Created, result.Data);
                    case OperationResult.Success:
                        return Request.CreateResponse(successStatusCode, result.Data);
                    default:
                        return Request.CreateResponse(HttpStatusCode.NotImplemented);
                }
            }
    
            #endregion Result handling
        }
