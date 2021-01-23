    public JsonResult GetUsersData()  
            {  
    		 var usersList = new List<UserModel>  
                {  
                    new UserModel  
                    {  
                        UserId = 1,  
                        UserName = "Ram",  
                        Company = "Mindfire Solutions"  
                    },  
                    new UserModel  
                    {  
                        UserId = 1,  
                        UserName = "chand",  
                        Company = "Mindfire Solutions"  
                    },  
                    new UserModel  
                    {  
                        UserId = 1,  
                        UserName = "Abc",  
                        Company = "Abc Solutions"  
                    }  
                };        
              
                return Json(usersList , JsonRequestBehavior.AllowGet);  
            }  
