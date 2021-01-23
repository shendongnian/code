    //GetAllProject return IList<ProjectModel>
    var projects = this.findProjectService.GetAllProjects(); 
    foreach(var project in projects)
    {
        var projectDb = context.Project.Where(e => e.Id == project.Id).FirstOrDefault();
        if (projectDb == null)
        {
            // the next line will map you a newproject and all of the partners and persons inside the each parnter if found ...
            // so you will get some entities which should be attached to the context in order for the ef to regonise that you mean not to insert new, but just to map them to the new project .. so
            //var newProject = Mapper.Map<ProjectModel, Project>(project);
            var newProject = context.Project.Create();
            // you should setup your mapping to not map the ID and let each mapsetup to map an entity itself not it's child entities
            newProject = Mapper.Map<ProjectModel, Project>(project);
            // loop all partners in the PROJECT MODEL
            foreach(var partner in project.PartnerModels) 
                ToPartners(partner, newProject.Partners);
            context.Project.Add(newProject);
            context.SaveChanges();
        }
    }
    public void ToPartners(PartnerModel model, ICollection<Partner> partners)
    {
        var partnerDb = context.Partner.Where(e => e.Id == model.Id).FirstOrDefault();
        if(parterDb == null) 
        {
            var newPartner = context.Partner.Create();
            newPartner = Mapper.Map<PartnerModel, Partner>(model);
            
            // loop all persons in the PARTNER MODEL
            foreach(var person in model.PersonsModel) 
                ToPersons(person, newPartner.Persons);
            partners.Add(newPartner);
        }
        else
        {
            // loop all persons in the PARTNER MODEL
            foreach(var person in model.PersonsModel) 
                ToPersons(person, partnerDb.Persons);
            // here the partner is attached to the context so he will not insert a new one, it will just add (map) it to the project.
            partners.Add(parterDb);
        }
    }
    public void ToPersons(PersonModel model, ICollection<Person> persons)
    {
        // MAP IT 
    }
