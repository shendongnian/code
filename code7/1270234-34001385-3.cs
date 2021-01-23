    public class GenericContractModelBinder : IModelBinder
    {
       public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
       {
          //I'm assuming your JSON is being sent in the content of the request
          string content = actionContext.Request.Content.ReadAsStringAsync().Result;
          var json = JArray.Parse(content); //you really should switch to "array by default" processing;the number of items in it is an implementation detail.
          //In my opinion, this "ContractTypeService" gets injected at CompositionRoot, which would be in the IHttpControllerActivator
          var contractType = actionContext.RequestContext.Configuration.DependencyResolver.GetService(typeof(ContractTypeService)).GetAmbientContractType();
          GenericContract contract = new GenericContract();
          foreach(var item in json.Children<JObject>())
          {
               contract.ContractValue = (double)item["ContractValue"].Value<JToken>();
               contract.ContractType = contractType;
             }
          }
          DecoupledType model = new DecoupledType()
          {
             Contract = contract
          };
          bindingContext.Model = model;
       }
    }
    public class DecoupledTypeModelBinderProvider : ModelBinderProvider
    {
       public override IModelBinder GetBinder(System.Web.Http.HttpConfiguration configuration, Type modelType)
       {
          return new DecoupledTypeModelBinder();
       }
    }
    ...(in your controller)
    public dynamic Post([ModelBinder(typeof(GenericContractModelBinderProvider))]DecoupledType bazinga)
    {
        var contract = bazinga.Contract;
        var contractType = contract.ContractType;
        var contractValue = contract.ContractValue;
    }
