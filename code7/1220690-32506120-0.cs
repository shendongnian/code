       public class FornecedorController : BaseController
        {
            protected FornecedorServices Service = new FornecedorServices();
    
            [HttpGet]
            [Authorize(Roles = ApplicationRoles.FORNECEDOR_VISUALIZAR)]
            [OutputCache(NoStore = false, Duration = 3600)]
            public JsonResult ListarJson(FornecedorParameters parameters)
            {
                var model = this.Service.Search(parameters)
                    .Select(x => new
                    {
                        Value = x.Codigo,
                        Description = x.CodigoNomeFantasia
                    });
                return this.Json(model, JsonRequestBehavior.AllowGet);
            }
    
        }
