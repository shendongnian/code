     //Loads only a Projeclist from sharepoint
        public SPpowerPlantList loadProjectFromSharePoint()
        {
            SPpowerPlantList powerPlantList = new SPpowerPlantList();
            
            ClientContext context = new ClientContext(powerPlantSite);
          
            List powerPlantsList = context.Web.Lists.GetByTitle("Power Plants");
            CamlQuery query = CamlQuery.CreateAllItemsQuery(100);
            //query.ViewXml = @"<View><Query> </Query></View>";
            ListItemCollection items = powerPlantsList.GetItems(query);
            //context.Load(web.Lists,
            //             lists => lists.Include(list => list.Title, // For each list, retrieve Title and Id. 
            //                                    list => list.Id,
            //                                    list => list.Description));
            context.Load(items);
            context.ExecuteQuery();
            foreach (ListItem listItem in items)
            {
                SPpowerPlant powerPlant = new SPpowerPlant();
                powerPlant.projectName = listItem["Title"].ToString();
                powerPlant.location = listItem["Location"].ToString();
                powerPlant.country = listItem["Country"].ToString();
                powerPlant.currency = listItem["Currency"].ToString();
                powerPlant.shortName = listItem["Short_x0020_Name"].ToString();
                powerPlant.spaceUrl = listItem["Space"].ToString();
                powerPlant.numberOfWtgs = Convert.ToInt32(listItem["Number_x0020_of_x0020_WTGs"]);
                //Console.WriteLine(listItem[""]);
                //powerPlantList.Add(powerPlant);
            }
            return null;
        }
