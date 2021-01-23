    // Summary:
            //     Creates an System.Net.Http.HttpResponseMessage wired up to the associated
            //     System.Net.Http.HttpRequestMessage.
            //
            // Parameters:
            //   request:
            //     The HTTP request message which led to this response message.
            //
            //   statusCode:
            //     The HTTP response status code.
            //
            //   value:
            //     The content of the HTTP response message.
            //
            // Type parameters:
            //   T:
            //     The type of the HTTP response message.
            //
            // Returns:
            //     An initialized System.Net.Http.HttpResponseMessage wired up to the associated
            //     System.Net.Http.HttpRequestMessage.
            public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value);
