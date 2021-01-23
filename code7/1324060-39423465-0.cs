    public static void FindTree(int? parent,List<Category> list,ref List<Category> result)
    	{
    		if(list!=null && list.Count >0)
    		{
    			var details = list.Where(x=>x.ParentId == parent).ToList();
    			foreach(var detail in details)
    			{
    				result.Add(detail);
    				FindTree(detail.Id,list,ref result);
    			}
    		}
    		
    	}
