    using(SPSite oSiteCollection = new SPSite("http://Server_Name"))
    {
        using(SPWeb oWebsite = oSiteCollection.OpenWeb("Website_URL"))
        {
    
    SpList list2Col = oWebsite.Lists["List2"];
    SPListItemCollection list2 = list2Col.GetItems("<Query><Where><Eq><FieldRef Name='Cust_ID' /><Value Type='Number'>"Your Customer ID From List1"</Value></Eq></Where></Query>");
    List<AllDatas> myDatas = new List<AllDatas>();
          foreach(SpListItem item in list2)
    {
    myDatas.add(new AllDatas(item));
    }
    var resultWithCorrectBranch = myDatas.Where(t=>t.Branch=="something"
        }
    }
