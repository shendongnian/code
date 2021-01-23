    Mapper.CreateMap<ItemFilterBlockGroup, ItemFilterBlockGroupViewModel>()
        .ForMember(destination => destination.ChildGroups, options => options.ResolveUsing(
            (resolution) =>
            {
                var includeAdvanced = (bool)resolution.Context.Options.Items["includeAdvanced"];
                var source = (ItemFilterBlockGroup)resolution.Context.SourceValue;
                if(includeAdvanced)
                    return source.ChildGroups;
                else
                    return source.ChildGroups.Where(c => c.Advanced == false);               
             }));
