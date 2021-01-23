    public class Handler
    {
          private readonly ProfileContext _db;
          private readonly IMapper _mapper;
          public Handler(ProfileContext db, IMapper mapper)
          {
              _db = db;
              _mapper = mapper;
          }
          public void Handle(Profile1 request)
          {
              ProfileModel profile = _mapper.Map<Profile1, ProfileModel>(request);
              _db.Profiles.Add(profile);
              try
              {
                  db.SaveChanges();
              }
              catch (Exception ex)
              {
                  throw;
              }
              return profile;
          }
    }
