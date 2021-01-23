    Mapper.CreateMap<Perm, PermViewModel>().ConvertUsing<PermConverter>();
    private class PermConverter : TypeConverter<Perm, PermViewModel>
    {
        protected override PermViewModel ConvertCore(Perm source)
        {
            return new PermViewModel() 
            {
                 //Set your parameters here. 
            };
        }
    }
