            public void toExcel()
        {
            var grid = new GridView();
            var iDConfig = blergo.Get_iDealConfigs(null, null, null, null, null, null, null, out retStatus, out errorMsg);
                var model = iDConfig.Select(ic => new iDealModel2
                {
                    SaPrefix = ic.PrefixName,
                    CalendarCode = ic.CalendarCodeName,
                    CashnCarry = ic.isCashnCarry,
                    FreeMM = ic.isFreeMM,
                    OnContract = ic.isOnContract,
                    ProductId = ic.ProductName,
                    RequestTypeId = ic.RequestTypeName
                }).ToList();
                grid.DataSource = from data in model.OrderBy(x => x.SaPrefix)
                                  select new
                                  {
                                      SAPrefix = data.SaPrefix,
                                      CalendarCode = data.CalendarCode,
                                      isCash = data.CashnCarry,
                                      FreeMM = data.FreeMM,
                                      onContract = data.OnContract,
                                      Product = data.ProductId,
                                      RequestType = data.RequestTypeId
                                  };
                grid.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=iDealConfig.xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);
                grid.RenderControl(htmlTextWriter);
                Response.Write(sw.ToString());
                Response.End();
        }
