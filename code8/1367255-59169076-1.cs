    public class HomeController : BaseController
        {
            [HttpGet]
            public async Task<ActionResult> Index()
            {
    
                string loginUserId = TempData[WebConstants.LoginUserId].ToString();
                string loginUserName = TempData[WebConstants.LoginUserName].ToString();
                string authmode = TempData[WebConstants.AuthenticationMode].ToString();
                HttpResponseMessage response_Cat = null;
                HttpResponseMessage response_Printer = null;
                IEnumerable<Catridge> list_Cat = null;
                IEnumerable<Printer> list_Printer = null;
    
                if (loginUserId == "1" && authmode == "Admin")
                {
                    CustomLogger.Write("Service Call: Get All Catridge: Start");
                    response_Cat = await ServiceGet(ClientConfig.ServiceLayerUrl + ClientConfig.GetAllCatridgeUrl);
                    CustomLogger.Write("Service Call: Get All Catridge: End");
    
                    var result_Cat = response_Cat.Content.ReadAsStringAsync().Result;
                    list_Cat = JsonConvert.DeserializeObject<IEnumerable<Catridge>>(result_Cat).OrderByDescending(s => s.Id);                    
    
    
                    CustomLogger.Write("Service Call: Get All Printer: Start");
                    response_Printer = await ServiceGet(ClientConfig.ServiceLayerUrl + ClientConfig.GetAllPrinterUrl);
                    CustomLogger.Write("Service Call: Get All Printer: End");
    
                    var result_Printer = response_Printer.Content.ReadAsStringAsync().Result;
                    list_Printer = JsonConvert.DeserializeObject<IEnumerable<Printer>>(result_Printer).OrderByDescending(s => s.Id);                    
    
                    dynamic mymodel = new ExpandoObject();
                    mymodel.Catridge = list_Cat;
                    mymodel.Printer = list_Printer;
                    return View(mymodel);
    
                }
    
    
                else
                {
                    CustomLogger.Write("Service Call: GetAllPrinters: Failed|" + response_Printer);
                    ModelState.AddModelError(Resources.Resource.MasterError, Resources.Resource.UnableToProcessRequest);
                    list_Printer = new List<Printer>();
                    return View(list_Printer.AsEnumerable());
                }
    
            }
    
        }
    
