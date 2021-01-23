    public void RenderMode(string layout)
    {
        if (IsPartialPage)
        {
            // Wipe any existing layout page
            ViewBag.Layout = null;
            return;
        }
        ViewBag.Layout = layout;
    }
