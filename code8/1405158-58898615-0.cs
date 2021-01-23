    public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotSupportedException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    JsonConvert.SerializeObject(new[] {context.Exception.Message}));
                return;
            }
            string exceptionMessage = null;
            // Validation Related Errors
            if (context.Exception is DbEntityValidationException)
            {
                var typedEx = context.Exception as DbEntityValidationException;
                if (typedEx == null)
                    return;
                var errorMessages = typedEx.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                exceptionMessage = string.Concat(typedEx.Message, " The validation errors are: ", fullErrorMessage);
            }
            // All Global Exceptions
            var innerException = context.Exception.GetBaseException();
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    Data = new
                    {
                        IsSuccess = false,
                        StatusCode = 45000,
                        ErrorMessage = exceptionMessage ??
                                       $"{innerException.Message} StackTrace : {innerException.StackTrace}"
                    }
                })),
                ReasonPhrase = "Deadly Exception!"
            });
        }
