    foreach (PublishedProject pubProj in projContext.Projects)
    {
       Console.WriteLine("\n\t{0} : {1}", pubProj.Name, pubProj.CreatedDate.ToString());
       projContext.Load(pubProj.Tasks);
       projContext.ExecuteQuery();
       foreach (PublishedTask item in pubProj.Tasks)
       {
          foreach (PublishedTask pubTask in pubProj.Tasks)
          {
             Console.WriteLine("\n{0}", pubTask.Name);
          }
       }
    }
