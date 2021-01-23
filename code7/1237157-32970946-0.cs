       [AuthorizeClientID]
            [LoggingFilter]
            public ActionResult SupplierReportSelection(int ClientID, int[] ReviewPeriodID, string RPString, int? GroupID, int? SupplierID = null, bool? Backbtn = null, int? StatusCategoryID = null) {
                if (GroupID == null && SupplierID == null && TempData["TempReviewPeriod"] != null) {
                    ReviewPeriodID = (int[])TempData["TempReviewPeriod"];
    
                    //The cookie code is used for the page refresh whenever a user performs a search with multiple ReviewPeriod IDs. This is because you cannot pass the ReviewPeriodID array in the URL.
                    Request.Cookies.Remove("RPCookie");
                    HttpCookie RPCookie = new HttpCookie("RPCookie");
                    for (int i = 0; i < ReviewPeriodID.Length; i++) {
                        if (ReviewPeriodID.Length - 1 != i) {
                            RPCookie.Value += ReviewPeriodID[i] + ",";
                        }
                        else {
                            RPCookie.Value += ReviewPeriodID[i];
                        }
                    }
                    Response.Cookies.Set(RPCookie);
                }
                else if (GroupID == null && SupplierID == null && TempData["TempReviewPeriod"] == null) {
                   ReviewPeriodID = Request.Cookies.Get("RPCookie").Value.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                    
                }
    
                ClaimsBySupplierViewModel SupplierModel = ClaimsBySupplier(ClientID, ReviewPeriodID, SupplierID, GroupID);
    
                ViewBag.client = client;
    
                return View("ClaimsBySupplier", SupplierModel);
            }
