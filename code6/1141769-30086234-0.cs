	public class Test
	{
		internal StructType<Test> _fieldName;
		
		public Test()
		{
			_fieldName = new StructType<Test>(this);
		}
	}
	public struct StructType<ParentT>
	{
		public StructType(ParentT parent)
		{
			_parent = parent;
		}
		internal ParentT _parent;
	}
