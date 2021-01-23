    	public static void WriteListToExcel<T>(HttpResponseBase Response, List<T> list, string fileName)
	    {
	        try
	        {
	            Response.Clear();
	            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", fileName));
	            Response.Charset = String.Empty;
	            Response.Cache.SetCacheability(HttpCacheability.NoCache);
	            Response.ContentType = "application/vnd.ms-excel";
	            
	            List<string> result = new List<string>();
	            result.Add(String.Format("{0}\n", String.Join(String.Empty, typeof(T).GetProperties().Select(i => String.Format("{0}\t", i.Name))))); // Headers
	            result.AddRange(list.Select(i => String.Format("{0}\n",String.Join("\t", i.GetType().GetProperties().Select(t => t.GetValue(i, null)))))); // Lines 
	            result.ForEach(i => Response.Write(i));
	            Response.End();
	        }
	        catch (Exception e)
	        {
	            // Error..
	        }
	    }
