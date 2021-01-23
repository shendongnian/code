    // the vwModel param is for reuse in our post later on..
    private ViewModel LoadViewModel(ViewModel vwModel)
    {
      if(vwModel == null)
        vwModel = new ViewModel();
      List<SelectListItem> List1 =
        new List<SelectListItem> {
          new SelectListItem { Text="list1-a", Value="list1-a" },
          new SelectListItem { Text="list1-b", Value="list1-b" },
          new SelectListItem { Text="list1-c", Value="list1-c" }
        }
      List<SelectListItem> List2 =
        new List<SelectListItem> {
          new SelectListItem { Text="list2-a", Value="list2-a" },
          new SelectListItem { Text="list2-b", Value="list2-b" },
          new SelectListItem { Text="list2-c", Value="list2-c" }
        }
      vwModel.ListItem1 = List1;
      vwModel.ListItem2 = List2;
      return vwModel;
    }
