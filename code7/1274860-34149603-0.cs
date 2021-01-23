    public class Test
    {
	    public static void Main()
	    {
		   Address a1 = new Address();
		   a1.AddressID = "100";
		
		   Address a2 = new Address();
		   a2.AddressID = "200";
		   Console.WriteLine(IsAddressModified(a1,a2,a=>a.AddressID));
	    }
	
	   public static bool IsAddressModified(Address a1,Address a2,params Expression<Func<Address,Object>>[] props)
	   {
		   if(props == null)
			  return a1.Equals(a2);
			
		  foreach(Expression<Func<Address,object>> memberExpression in props)
		  {
			  MemberExpression property = memberExpression.Body as MemberExpression;
			  if(property != null)
			  {
				  foreach(PropertyInfo pi in typeof(Address).GetProperties())
				  {
					// exclude all properties we passed in
					  if(!pi.Name.Equals(property.Member.Name))
					  {
						
						  var valueA1 = pi.GetValue(a1);
						  var valueA2 = pi.GetValue(a2);
						  if(valueA1 != null && valueA2 != null)
							  if(!valueA1.Equals(valueA2))
								  return true;
					  }
				  }
			  }
		  }
		
		  return false;
	  }
    }
