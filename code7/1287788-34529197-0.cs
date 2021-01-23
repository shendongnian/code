    public ActionResult PGResponse()
    {
            string strPGResponse = HttpContext.Current.Request.Form["msg"];
            string strMerchantCode = HttpContext.Current.Request.Form["tpsl_mrct_cd"];
    
    
            List<Cart> CartList = await _cartService.GetByUserBasicID(Convert.ToInt64(custid));
            if(success){
                 return View("success.html");
            }
            return View("failed.html");  // return your angular application page.
    }
