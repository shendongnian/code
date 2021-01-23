    if (ModelState.IsValid)
    {
        if (string.IsEmptyOrWhitespace(model.LookingFor))
        {
            model.ContactList = contactRepository.GetAll(filter: x => x.UserId == user.Id);
        }
        else
        {
            model.ContactList = contactRepository.GetAll(
                    filter: x => x.FullName.Contains(model.LookingFor));
        }
        if(model.FullNameIsChecked)
        {
            model.ContactList.OrderBy(f => f.FullName);
        }
        else
        {
            model.ContactList.OrderBy(e => e.Email); 
        }
    }
    else
    {
        model.ContactList = contactRepository.GetAll(filter: x => x.UserId == user.Id);
    }
