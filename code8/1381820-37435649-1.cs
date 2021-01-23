    		Item baseitem = Database.GetDatabase("master").SelectSingleItem(sitecore_path);
			if (baseitem != null)
			{
						//Sitecore.Caching.CacheManager.ClearAllCaches();  
						string load = String.Concat(new object[] { "item:load(id=", baseitem.ID, ",language=", baseitem.Language, ",version=", baseitem.Version, ")" });
						Sitecore.Context.ClientPage.SendMessage(this, load);
						String refresh = String.Format("item:refreshchildren(id={0})", baseitem.Parent.ID);
						Sitecore.Context.ClientPage.ClientResponse.Timer(refresh, 2);
			}
