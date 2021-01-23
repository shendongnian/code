    Mapper.CreateMap<ItemFilterBlockGroup, ItemFilterBlockGroupViewModel>()
        .ConstructUsing(context => 
        {
            var showAdvanced =  (bool)context.Options.Items["showAdvanced"];
            if (showAdvanced)
            {
                // Map and return new ItemFilterBlockGroupViewModel.
            }
            else
            {
                // Map with non advanced items only and return new
                // ItemFilterBlockGroupViewModel.
            }
        });
