    public class SystemUserDto
    {
      [Display(Name = "User")]
      public string Username { get; set; }
      [Display(Name = "Admin")]
      public Nullable<bool> Type { get; set; }
    }
    ...
    Mapper.CreateMap<SystemUser, SystemUserDto>();
    ...
    public IEnumerable<SystemUserDto> GetAll()
    {
        var Users = Ctx.SystemUsers.Project().To<SystemUserDto>();
    }
