    CreateMap<Models.Job, Models.API.Job>(MemberList.Source);
    CreateMap<StaticPagedList<Models.Job>, StaticPagedList<Models.API.Job>>()
                    .ConstructUsing((source, context) => new StaticPagedList<Models.API.Job>(
                        context.Mapper.Map<List<Models.Job>, List<Models.API.Job>>(source.ToList()),
                        source.PageNumber,
                        source.PageSize,
                        source.TotalItemCount));
