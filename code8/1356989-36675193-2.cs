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
            //When you use the yield keyword in a statement, you indicate that the method, operator, or get accessor in which it appears is an iterator.
            yield return new ContactResultModel(){            
                Id  = a.Id,
                CustomerId = a.CustomerId
            };
        }
    }
