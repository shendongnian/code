    from IA in contextObj.InspectionArchives 
    join cl in contextObj.Clients on IA.CustomerID equals Cl.Id
    join IaIa in contextObj.InspectionAuthorityInspectionArchives On IA.Id equals IaIa .InspectionArchive_Id
    join IAuth in contectObj.InspectionAuthorities on IaIa.InspectionAuthority_Id equals IAuth.Id  
    join OTIA in contextObj.ObjectTypeInspectionArchives on IA.Id equals OTIA.InspectionArchive_Id
    join ObjT in contextObj.ObjectTypes on OTIA.ObjectType_Id equals ObjT.Id
    where (Cl.Id = 1 || Cl.Id = 2)
    group new {cl, IAuth} by new {Cl.ClientName, IAuth.Description} into grp
    select new 
    {
      clientName = grp.key.ClientName,
      Desc = grp.key.Description,
      NumberOfObjectTypes = grp.Count(g=>g.ObjT.Description.Distinct())
    };
