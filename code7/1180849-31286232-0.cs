    if (ModelState.IsValid)
    {
        if (model.LookingFor == null)
        {
            model.ContactList = contactRepository.GetAll(filter: x => x.UserId == user.Id);
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
            model.ContactList = contactRepository.GetAll(
                        filter: x => x.FullName.Contains(model.LookingFor));
            if(model.FullNameIsChecked)
            {
                model.ContactList.OrderBy(f => f.FullName);
            }
            else
            {
                model.ContactList.OrderBy(e => e.Email);
            }
        }
    }
    else
    {
        model.ContactList = contactRepository.GetAll(filter: x => x.UserId == user.Id);
    }
