    foreach (var result in results)
    {
        Item hit = result.GetObject<Item>();
        if (hit != null)
        {
            // Potentially you need to just check the __Renderings or
            // __FinalRenderings field here instead
            if (hit.Visualization.Layout == null) 
            {
                foreach (Sitecore.Globals.LinkDatabase.GetReferrers(item)) 
                {
                    //Do something
                }
            }
        }
    }
