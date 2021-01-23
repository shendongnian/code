    public static class MyClassFactory
    {
        public static MyClass FromMyClassDto(MyClassDto myClassDto)
        {
            return AutoMapper.LoadEntityFromDto<MyProject.DTO.MyClassDto, MyClass>(myClassDto);
        }
    }
