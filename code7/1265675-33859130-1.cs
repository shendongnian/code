    public class MapperProfile : Profile
    {
        protected override void Configure()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
            // calling non-static CreateMap
            CreateMap<User, DAL.Models.User>();
            CreateMap<DAL.Models.User, User>();
            CreateMap<Role, DAL.Models.Role>();
            CreateMap<DAL.Models.Role, Role>();
            CreateMap<Task, DAL.Models.Task>();
            CreateMap<DAL.Models.Task, Task>();
            CreateMap<TaskReport, DAL.Models.TaskReport>();
            CreateMap<DAL.Models.TaskReport, TaskReport>();
            CreateMap<Project, DAL.Models.Project>();
            CreateMap<DAL.Models.Project, Project>();
        }
    }
