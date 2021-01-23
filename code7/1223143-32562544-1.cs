    [HttpGet]
    public JsonResult FetchProducts(string type, string category, string country, string subsidary, DateTime? date)
    {
	   var data = (from P in db.AB_Product
							join S in db.AB_Subsidary on P.Subsidary_ID equals S.SubsidaryID
							where P.Status != "Active" AND
								  P.ProductTypeID = type AND
								  P.ProductCategoryID = category AND
								  P.CountryID = country AND
								  P.SubsidaryID = subsidary AND
								  P.Date = date
							select new
							{
								ID = p.Product_ID,
								Name = p.Product_Name_En,
								Category = p.ProductCategory_ID
							}
				  ).ToList();
	    return Json(data, JsonRequestBehavior.AllowGet);
    }
