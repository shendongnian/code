    class MyObjectViewModel
    {
        //actually comes from WebService, but that doesnt matter here
        List<PersonViewModel> AllPeople= {person1,person2, etc}
        int SelectedPersonId;
    }
    @model MyModels.MyObjectViewModel
    
    @Html.DropDownListFor(m=> m.SelectedPersonId, 
          Model.AllPeople.Select(p=>new SelectListItem{Value = p.Id, Text=p.Name}))
