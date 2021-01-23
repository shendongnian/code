    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        response.StatusCode == HttpStatusCode.OK;
                        return response;
                    }
                    else
                    {
                        throw new HttpResponseException(
         Request.CreateErrorResponse(HttpStatusCode.Unauthorized, myCustomMessage));
                    }
