    public JsonResult GetCustomerById(Guid id)
    {
        CustomerModel customer = new CustomerManager().GetById(id);
        CustomerResultModel output = new CustomerResultModel(){
            id = customer.Id,
            Contacts = GetContacts(customer.Contacts)
        };
        return Json(output, JsonRequestBehavior.AllowGet); 
        //If you only POST then remove the AllowGet (the action name says Get so I'm assuming
    }
    private IEnumerable<ContactResultModel> GetContacts(Contacts){
        foreach(var a in Contacts){
            yield return new ContactResultModel(){            
                Id  = a.Id,
                CustomerId = a.CustomerId
            };
        }
    }
