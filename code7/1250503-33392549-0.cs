    public MyClass
    {
    	public static MyClass FromDto(MyClassDto myClassDto)
    	{
    		return AutoMapper.LoadEntityFromDto<MyProject.DTO.MyClassDto, MyClass>(myClassDto);
    	}
    
    	//Properties
    }
