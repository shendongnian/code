                SPWeb currentWeb = (SPWeb)properties.Feature.Parent;
                try
                {
                SPLimitedWebPartManager NewForm = currentWeb.GetLimitedWebPartManager("Lists/listname1/NewForm.aspx", System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);
                AddWebPart(NewForm);
      	        }
            	catch (Exception)
            	{
                	throw;
            	}
              }
