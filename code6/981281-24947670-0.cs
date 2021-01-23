    public ActionResult Create(SiteViewModel siteViewModel)
    {
        if (ModelState.IsValid)
        {
            Site newSite = new Site();
            newSite = Mapper.Map<SiteViewModel, Site>(siteViewModel);
            newSite.Address.Country = DbContext.Countries.FirstOrDefault(x => x.Id == siteViewModel.Address.Country.CountryId);
            newSite.DateCreated = DateTime.Now;
            _unitOfWork.SiteRepository.Insert(newSite);
            _unitOfWork.Save();
            ...
        }
    }
