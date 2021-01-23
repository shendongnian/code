    public ActionResult RenderMenu()
    {
      // Build the data needed to render the menu. Pass to the view
     
        var menu = new List<MenuItem>
        {
            new MenuItem(){
                Text = "Home",
                Childs = new List<MenuItem>
                {
                    new MenuItem {Text = "About"}
                }
            }
        };
      return PartialView(menuItems);
    }
