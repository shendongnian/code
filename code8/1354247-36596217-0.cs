    [Route("Retailers/{search}")]
    [HttpGet]
    public async Task<List<Lookup>> Retailers(string search)
    {
        var user = UserManager.FindById(User.Identity.GetUserId());
        Guid userId = Guid.Parse(user.Id);
    
        var companies = await _unitOfWork.GetRepository<Company>().GetAll().Where(c => c.CompanyType == CompanyType.Retail && 
                    (c.UserID == null || c.UserID == userId) && c.CompanyName.StartsWith(search)).Take(5)
                    .Select(x => new Lookup { Id = x.Id, Name = x.CompanyName }).ToListAsync();
    
        return companies;
    }
