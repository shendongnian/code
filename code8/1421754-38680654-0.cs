     public JsonResult Edit(List<TaskControllerViewModel> model)
        {
            foreach(var item in model)
            {
                var userToEdit = users.GetUser(item.Id);
                if(userToEdit != null)
                {
                    userToEdit.Contact.FirstName = item.FirstName;
                    userToEdit.Contact.LastName = item.LastName;
                    userToEdit.Username = item.UserName;
                    userToEdit.Contact.Address = item.Address;
                    userToEdit.IsActive = item.IsActive;
                }
                unitOfWork.SaveChanges();
            }
            
            return Json(model);
        }
