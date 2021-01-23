    var newReviews = (from r in myEntities.Reviews
                                     orderby r.Id
                                     select r).FirstOrDefault();
    if(newReviews != null)
    {
        var tempList = new List<dynamic>();
        tempList.Add(newReviews);
        GridView1.DataSource = tempList;
        GridView1.DataBind();
    }
