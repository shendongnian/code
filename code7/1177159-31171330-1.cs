    Mapper.CreateMap<ItemFilterBlockGroup, ItemFilterBlockGroupViewModel>()
        .ForMember(destination => destination.ChildGroups, options => options.ResolveUsing(
            delegate(ResolutionResult resolutionResult)
            {
                var context = resolutionResult.Context;
                var showAdvanced = (bool)context.Options.Items["showAdvanced"];
                var group = (ItemFilterBlockGroup)context.SourceValue;
                if(showAdvanced)
                    return group.ChildGroups;
                else
                    return group.ChildGroups.Where(c => c.Advanced == false);               
             }));
