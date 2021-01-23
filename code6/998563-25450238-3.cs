    public static void RenderMode(this Controller controller, layout)
    {
         if (!controller.Request.IsAjaxReuest())
         {
             controller.ViewBag.Layout = layout;
         }
    }
