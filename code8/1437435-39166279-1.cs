         List<AddOnTrigger> triggerlist = new List<AddOnTrigger>();
        triggerList.Add(new AddOnTrigger
        {
	     AddOnTriggerItems = gvTriggerProduct.Rows.Cast<GridViewRow>().Select(rowItem => new AddOnTriggerItem()
		{
			ProductTypeID = gvTriggerProduct.Rows[rowItem.RowIndex].Cells[1].Text.ToString(),
			ProductCode = gvTriggerProduct.Rows[rowItem.RowIndex].Cells[2].Text.ToString(),		
			CreatedTime = DateTime.Now,
			ModifiedTime = DateTime.Now
		}).ToList(),
		ActiveStatus = 1,
		CreatedTime = DateTime.Now,
		ModifiedTime = DateTime.Now}
        });
        ProjectA.TEST.BE.AddOn addOn = new ProjectA.TEST.BE.AddOn()
        { 
	       AddCode = addCode,          
	       CreatedTime = DateTime.Now,
	       ModifiedTime = DateTime.Now,
	       AddOnTriggers = triggerlist
	       AddOnProducts = gvAddOnProduct.Rows.Cast<GridViewRow>().Select(rowAddOnProducts => new AddOnProduct()
	       {
		      ProductTypeID =    gvAddOnProduct.Rows[rowItem.RowIndex].Cells[2].Text.ToString(),	
		      ProductCode = gvAddOnProduct.Rows[rowItem.RowIndex].Cells[2].Text.ToString(),	
	          CreatedTime = DateTime.Now,
	    	  ModifiedTime = DateTime.Now,
	     	  AddOnProductAllotments = addOnProductAllotmentSession.Where(p => (p.ProductID == (Convert.ToString(((HiddenField)rowAddOnProducts.FindControl("ProductID")).Value )))).ToList(),      
	    }).ToList()
        };
