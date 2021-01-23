    @if (ViewBag.List != null)
    {
        var last_item = (ViewBag.List as IEnumerable<int[]>)[(ViewBag.List as IEnumerable<int[]>).Count()-1];
        foreach(var item in ViewBag.List)
        {
            if(item[0] == last_item ) // here I want to check if it is the last item in my ViewBag.List
            { 
                /* do stuff */ 
            } 
        }
    }
