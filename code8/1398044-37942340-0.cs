    Mapper.CreateMap<User, UserViewModel>()
                .ForMember(a => a.Id, b => b.ResolveUsing(c => c.Id))
                .ForMember(a => a.VMAddress, b => b.ResolveUsing(c => c.Addresses));
    Mapper.CreateMap<Address, VMAddress>()
                .ForMember(a => a.Name, b => b.ResolveUsing(c => c.Name));
    var map = Mapper.Map<UserViewModel>(new User
            {
                Id = "ID",
                Addresses = new List<Address>
                {
                    new Address{ Name = "name1"} ,
                    new Address{ Name = "name2"}
                }
            });
