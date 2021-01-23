    TryUpdateModel(model);
    if(ModelState.IsValid)
    {
      model.ContactList = contactRepository.GetAll(filter: x => x.UserId == user.Id);
      if(model.LookingFor == null)
      {
    		if(model.FullNameIsChecked)
    		{
    			 model.ContactList.Sort((x, y) => string.Compare(x.FullName, y.FullName));
    		}
    		else
    		{
    			 model.ContactList.Sort((x, y) => string.Compare(x.Email, y.Email));
    		}
      }
      else
      {
    		if(model.FullNameIsChecked)
    		{
    			model.ContactList = contactRepository.GetAll(filter: x => x.FullName.Contains(model.LookingFor));
                model.ContactList.OrderBy(f => f.FullName);
    		}
    		else
    		{
    			model.ContactList = contactRepository.GetAll(filter: x => x.Email.Contains(model.LookingFor));
    			model.ContactList.OrderBy(e => e.Email);
    		}
      }
    }
