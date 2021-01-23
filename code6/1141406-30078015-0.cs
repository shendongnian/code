    internal static MasterPage CreateMaster(TemplateControl owner, HttpContext context, VirtualPath masterPageFile, IDictionary contentTemplateCollection)
    {
    	MasterPage masterPage = null;
    	if (masterPageFile == null)
    	{
    		if (contentTemplateCollection != null && contentTemplateCollection.Count > 0)
    		{
    			throw new HttpException(SR.GetString("Content_only_allowed_in_content_page"));
    		}
    		return null;
    	}
    	else
    	{
    		VirtualPath virtualPath = VirtualPathProvider.CombineVirtualPathsInternal(owner.TemplateControlVirtualPath, masterPageFile);
    		ITypedWebObjectFactory typedWebObjectFactory = (ITypedWebObjectFactory)BuildManager.GetVPathBuildResult(context, virtualPath);
    		if (!typeof(MasterPage).IsAssignableFrom(typedWebObjectFactory.InstantiatedType))
    		{
    			throw new HttpException(SR.GetString("Invalid_master_base", new object[]
    			{
    				masterPageFile
    			}));
    		}
    		masterPage = (MasterPage)typedWebObjectFactory.CreateInstance();
    		masterPage.TemplateControlVirtualPath = virtualPath;
    		if (owner.HasControls())
    		{
    			foreach (Control control in owner.Controls)
    			{
    				LiteralControl literalControl = control as LiteralControl;
    				if (literalControl == null || Util.FirstNonWhiteSpaceIndex(literalControl.Text) >= 0)
    				{
    					throw new HttpException(SR.GetString("Content_allowed_in_top_level_only"));
    				}
    			}
    			owner.Controls.Clear();
    		}
    		if (owner.Controls.IsReadOnly)
    		{
    			throw new HttpException(SR.GetString("MasterPage_Cannot_ApplyTo_ReadOnly_Collection"));
    		}
    		if (contentTemplateCollection != null)
    		{
    			foreach (string text in contentTemplateCollection.Keys)
    			{
    				if (!masterPage.ContentPlaceHolders.Contains(text.ToLower(CultureInfo.InvariantCulture)))
    				{
    					throw new HttpException(SR.GetString("MasterPage_doesnt_have_contentplaceholder", new object[]
    					{
    						text,
    						masterPageFile
    					}));
    				}
    			}
    			masterPage._contentTemplates = contentTemplateCollection;
    		}
    		masterPage._ownerControl = owner;
    		masterPage.InitializeAsUserControl(owner.Page);
    		owner.Controls.Add(masterPage);
    		return masterPage;
    	}
    }
