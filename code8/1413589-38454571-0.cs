       public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                var result = new Result { Status = Result.EStatus.Error, ErrorText = ExceptionToString(ex) };
                this.ReturnFormattedResult(result, HttpStatusCode.Unauthorized, context);
            }
            catch (Exception ex)
            {
                var result = new Result { Status = Result.EStatus.Error, ErrorText = ExceptionToString(ex) };
                this.ReturnFormattedResult(result, HttpStatusCode.InternalServerError, context);
            }
        }
        private void ReturnFormattedResult(Result result, HttpStatusCode code, IOwinContext context)
        {
            // what should our response be?
            var mediaType = context.Request.MediaType ?? context.Request.ContentType;
            // use the accept header (unless it is empty or '*/*' in which case use the content-type
            if (!string.IsNullOrEmpty(context.Request.Accept) && !context.Request.Accept.Contains("*/*"))
            {
                mediaType = context.Request.Accept;
            }
            // find a formatter for this media type, if no match then use the first one
            var formatter = this.config.Formatters.FindWriter(typeof(Result), new MediaTypeHeaderValue(mediaType));
            if (formatter == null)
            {
                formatter = this.config.Formatters.First();
                mediaType = formatter.SupportedMediaTypes.First().MediaType;
            }
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = mediaType;
            formatter.WriteToStreamAsync(typeof(Result), result, context.Response.Body, null, null).Wait();
        }
