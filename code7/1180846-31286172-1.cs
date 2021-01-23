    //Place this here since it's non conditional
    model.ContactList = contactRepository.GetAll(filter: x => x.UserId == user.Id);
    if(ModelState.IsValid)
    {
    	if(model.LookingFor == null)
    	{
    		if(model.FullNameIsChecked){
    			//...
    		}else
    		{
    			//...
    		}
    	}else
    	{
    		if(model.FullNameIsChecked){
    			//...
    		}else
    		{
    			//...
    		}
    	}
    }
    else
    {
    	//...
    }
