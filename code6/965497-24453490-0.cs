    namespace BusinessObjects
    {
	public class class_BusinessObjects
	{
		int StusentId;		
        	string StudentName;        
		
		public class_BusinessObjects ()
		{		
			StusentId = 0;
			StudentName = string.Empty;
		}
		
		public int StusentId
        	{
            		get
			{  
				return Id;
            		}
            		set
            		{
                		Id = value;
            		}
        	}		
       		public string StudentName
        	{
            		get
            		{
                		return Name;
            		}
            		set
            		{
                		Name = value;
            		}
        	}        
	}
    }
    using BusinessObjects;
    namespace MyModel
    {
	public class A
	{
		public class_BusinessObjects Dispaly(int id, string name)
        	{
			class_BusinessObjects obj = new class_BusinessObjects();
			obj.StusentId = id;
			obj.StudentName = name;
			return obj;
		}
	}
    }
