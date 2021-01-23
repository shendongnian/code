		[HttpPost]
		 public string GetCustomers()
		 {
			 List<Customers> listCustomers = new List<Customers>(); 
              /* the list of customers that is returned from the 
                database or from where you are picking the data*/
			CustomersViewModel model = new CustomersViewModel(){
					customers = listCustomers;
				}	
 
			 return Json(model, JsonRequestBehavior.AllowGet);          
		 }
