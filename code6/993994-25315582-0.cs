    string[] line = { "peter has", "julia has", "elvis has", "carol has" };
    string[] mylist = {"peter", "elvis"};
    List<string> newitems = new List<string>();
    string checkeditem;
    foreach (var item in line)
    {
        foreach (var check in mylist)
        {
            if (item.Contains(check))
            {
                checkeditem = item.Replace("has", "checked");
                newitems.Add(checkeditem);
            }
        }
                    
    }
    //You can bind the newitems with your textbox1 here
