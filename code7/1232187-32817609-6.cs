    @if (ViewBag.List != null)
    {
        IEnumerable<int[]> viewbag_list = (ViewBag.List as IEnumerable<int[]>);
        var last_item = viewbag_list[viewbag_list.Count()-1];
        foreach(var item in ViewBag.List)
        {
            if(item[0] == last_item[0]) // here I want to check if it is the last item in my ViewBag.List
            { 
                /* do stuff */ 
            } 
        }
    }
