    x.CreateMap<int, SongCategory>()
        .IgnoreAllNonExisting()
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src));
    x.CreateMap<UploadSongViewModel, Song>()
        .IgnoreAllNonExisting()
        .ForMember(dest => dest.AudioName, opt => opt.MapFrom(src => src.SongName))
        .ForMember(dest => dest.AudioPath, opt => opt.MapFrom(src => src.SongPath))
        .ForMember(dest => dest.SongCategories, opt => opt.MapFrom(src => src.SelectedCategoryIds))
        .AfterMap((viewModel, model) => 
        {
            foreach (var item in model.SongCategories)
            {
                item.Id = viewModel.Id;
            }
        });
