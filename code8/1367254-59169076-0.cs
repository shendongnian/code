    I have faced the same issue and I have find the solution. I am using the WebGrid to bind the data from two tables and display in a single page.   
    
    
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
    
    
    Now, I have binded the controller result data to WebGrid in MVC.
    
    MVC view Name : Index.cshtml
    
    
    
    @model dynamic   
    
    
    <div class="container">
        <div class="row">
            <h1 class="mainHeading col-md-12"><b>Cartridge List</b></h1>
        </div>  
    
        <div class="row">
            @{
                WebGrid grid_Cart = new WebGrid(Model.Catridge, canPage: true, rowsPerPage: 5);
                @grid_Cart.GetHtml(
             htmlAttributes: new { id = "GridTable_Cart" },
             tableStyle: "table table-bordered table-striped",
    
            columns: new[] {
    grid_Cart.Column("TeamName",header: "Team Name", canSort:false,style : "gridTableID"),
    grid_Cart.Column("PartNo",header: "PartNo", canSort:false,style : "gridTableID"),
    grid_Cart.Column("PrinterName",header: "Printer Name", canSort:false,style : "gridTableID"),
    grid_Cart.Column("LoginUserName",header: "Requester Name", canSort:false,style : "gridTableID"),
    grid_Cart.Column("CatridgeColor",header: "Cartridge Color", canSort:false,style : "gridTableID"),
    grid_Cart.Column("CatridgeDrumsColor",header: "DrumsColor", canSort:false,style : "gridTableID"),
    grid_Cart.Column("Others",header: "Others", canSort:false,style : "gridTableID"),
    grid_Cart.Column("AssigneeName",header: "Assignee", canSort:false,style : "gridTableID"),
    grid_Cart.Column("Status",header: "Status", canSort:false,style : "gridTableID")
         })
            }
    
        </div>
    </div>
    
    <div class="container">
        <div class="row">
            <h1 class="mainHeading col-md-12"><b>Printer List</b></h1>
        </div>
    
        <div class="row">
            @{
                WebGrid grid_printer = new WebGrid(Model.Printer, canPage: true, rowsPerPage: 5);
                @grid_printer.GetHtml(
        htmlAttributes: new { id = "GridTable_Printer" },
        tableStyle: "table table-bordered table-striped",
    
        columns: new[] {
        grid_printer.Column("TeamName",header: "Team Name", canSort:false,style : "gridTableID"),
        grid_printer.Column("PrinterName",header: "Printer Name", canSort:false,style : "gridTableID"),
        grid_printer.Column("Version",header: "Version", canSort:false,style : "gridTableID"),
        grid_printer.Column("Bundle",header: "Printer Bundle", canSort:false,style : "gridTableID"),
        grid_printer.Column("PrinterFloorNo",header: "FloorNo", canSort:false,style : "gridTableID"),
        grid_printer.Column("PrinterDeskNo",header: "DeskNo", canSort:false,style : "gridTableID"),
        grid_printer.Column("AssigneeName",header: "Assignee", canSort:false,style : "gridTableID"),
        grid_printer.Column("Status",header: "Status", canSort:false,style : "gridTableID")
                    })
            }
    
        </div>
    </div>
    
    
    Output for this above code find in attachment.
    [![enter image description here][1]][1]
    
    
      [1]: https://i.stack.imgur.com/O96K2.png
    
    
    Please let us know if anyone need any more clarification.
