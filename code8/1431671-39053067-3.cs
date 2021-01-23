    public class MyProfile : Profile
    {
    	public MyProfile()
    	{
    		this.CreateMap<MyTable, MyTableModel>();
    		this.CreateMap<int, MyEnum>().ProjectUsing(x => (MyEnum)x);
    		this.NullSubstitute<int, MyEnum>((int)MyEnum.Value1);
    	}
    }
