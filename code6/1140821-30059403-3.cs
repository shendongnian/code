    Public PartialViewResult _Search(string searchTerm, string specField, string searchType)
     {
         ViewData.Model = SearchRequests(searchTerm, specField, searchType).ToList();
         Return partialView();
     } 
