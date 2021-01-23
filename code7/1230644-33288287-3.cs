    public static void HandleRenderingException(TextWriter writer, Exception ex, string baseTypeName, object owner)
    {
    	Log.Error("Rendering Error", ex, owner);
    
    	if (Context.PageMode.IsNormal)
    	{
    		writer.WriteLine("<!--");
    		writer.WriteLine("[Your comment or serialized exception]");
    		writer.WriteLine("-->");
    	}
    	else
    	{
    		writer.WriteLine("<div class=\"rendering-exception\">");
    		writer.WriteLine("[Your comment or serialized exception]");
    		writer.WriteLine("</div>");
    	}
    
    	HttpContext.Current.Server.ClearError();
    }
