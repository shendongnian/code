     public class ContractsController : Controller
        {
            //
            // Static variables for Demo only
            static ContractModel model;
            static ICollection<ContractCurrencyClause> tmpContractCurrencyClauses { get; set; }
    
            public ActionResult Index()
            {
                if (model == null)
                {
                 model = new ContractModel();
                 tmpContractCurrencyClauses = new HashSet<ContractCurrencyClause>();
                 model.ContractCurrencyClauses = tmpContractCurrencyClauses;
                }
                model.ContractCurrencyClauses = tmpContractCurrencyClauses;
                return View(model);
            }
    
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Create(ContractCurrencyClause contract)
            {
                contract.CONTRACT_ID = new Guid();
                tmpContractCurrencyClauses.Add(contract);
                RouteValueDictionary routeValues = this.GridRouteValues();
               
                return RedirectToAction("Index", routeValues);
            }
    
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Update(ContractCurrencyClause contract)
            {
                tmpContractCurrencyClauses.Add(contract);
                RouteValueDictionary routeValues = this.GridRouteValues();
    
                return RedirectToAction("Index", routeValues);
            }
        }
