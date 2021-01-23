    //var sql = "delete from PersonCompany where Person.Id in (:idList) or Company.Id in (:idList)";
    var sql = "from PersonCompany where Person.Id in (:idList) or Company.Id in (:idList)";
    var query = NHibernateHelper.CurrentSession.CreateQuery(sql);
    query.SetParameterList("idList", contactIdList);
    query.SetTimeout(0);
    //query.ExecuteUpdate();
    var list = query.List<PersonCompany >();
    foreach (var item in list)
    {
        session.Delete(item);
    }
    session.Flush();
