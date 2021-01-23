     public class OptionsHttpMessageHandler : DelegatingHandler
    {
      protected override Task<HttpResponseMessage> SendAsync(
      HttpRequestMessage request, CancellationToken cancellationToken)
      {
        if (request.Method == HttpMethod.Options)
          {
             var apiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
              var controllerRequested = request.GetRouteData().Values["controller"] as string;              
              var supportedMethods = apiExplorer.ApiDescriptions.Where(d => 
                 {  
                    var controller = d.ActionDescriptor.ControllerDescriptor.ControllerName;
                    return string.Equals(
                        controller, controllerRequested, StringComparison.OrdinalIgnoreCase);
                })
              .Select(d => d.HttpMethod.Method)
              .Distinct();
          if (!supportedMethods.Any())
             return Task.Factory.StartNew(
                 () => request.CreateResponse(HttpStatusCode.NotFound));
          return Task.Factory.StartNew(() =>
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Headers.Add("Access-Control-Allow-Origin", "*");
                resp.Headers.Add(
                    "Access-Control-Allow-Methods", string.Join(",", supportedMethods));
                return resp;
            });
    }
    return base.SendAsync(request, cancellationToken);
      }
    }
