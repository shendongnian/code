        @{
        var pLRO = PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(
              new AjaxOptions() { 
                 HttpMethod = "GET", 
                 UpdateTargetId = "tableAndPaginationDiv" 
              }
           );
        //and now here set all the properties you want
        pLRO.DisplayLinkToFirstPage = PagedListDisplayMode.Always;
        pLRO.DisplayLinkToLastPage = PagedListDisplayMode.Always;
        //you can even style the format
        pLRO.LinkToFirstPageFormat = "First";
        pLRO.LinkToLastPageFormat = "Last";
        }
        //the rest of your view
        //...
        //and when you insert the pager just pass the pLRO variable
       @Html.PagedListPager(Model.PagedList, page => Url.Action("SearchTable",     "JobOffer", 
         new {
          randomParameters = "BANANAS"
          page = page
         }), pLRO 
       )
