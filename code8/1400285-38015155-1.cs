                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500; // or another Status accordingly to Exception Type
                        context.Response.ContentType = "application/json";
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            var ex = error.Error;
                            await context.Response.WriteAsync(new ErrorDto()
                            {
                                Code = <your custom code based on Exception Type>;
                                Message = ex.Message
                            }.ToString(), Encoding.UTF8);
                        }
                    });
                });
