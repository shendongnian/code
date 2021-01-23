     [HttpPost]
            public JsonResult GetUserByGenderId(int? genderId)
            {
                var list =  AllUsers.Where(a => a.genderId == genderId);// filter user
                return Json(list);// return  serialized json or 
                return Json(list.Select(a=>new { a.UserName,a.UserId }).Tolist());
    
            }
