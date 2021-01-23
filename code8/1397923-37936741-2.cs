            var Data= Search(user);  //get search result using any approach, maybe a service or etc
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, VM_User>()
                .ForMember(vm => vm.GENDER, opt => opt.MapFrom(u => u.GENDER == 10 ? "Male" : "Female")));
           
            List<VM_User> users = new List<VM_User>();
            for (int i = 0; i < Data.Count; i++)
            {
                users.Add(config.CreateMapper().Map<VM_User>(Data[i]));
            }
  
