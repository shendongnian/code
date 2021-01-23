        static void CreateMapForEntityId<T>()
        {
            Mapper.CreateMap<T, EntityId<T>>()
                .ForMember(_ => _.Id, options => options.MapFrom(_ => _));
        }
        static void TestMapping(int id)
        {
            CreateMapForEntityId<int>();
            Mapper
                .CreateMap<Entity, EntityDto>()
                .ForMember(_ => _.EntityId, options => options.MapFrom(_ => _.EntityId.Id))
                .ReverseMap();
            Mapper.AssertConfigurationIsValid();
            var entity = new Entity { EntityId = new EntityId<int> { Id = id } };
            var entityDto = Mapper.Map<EntityDto>(entity);
            Debug.Assert(entityDto.EntityId == id);
            var entityClone = Mapper.Map<Entity>(entityDto);
            Debug.Assert(entityClone.EntityId.Id == id);
        }
