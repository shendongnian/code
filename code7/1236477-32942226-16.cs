    public static ControllerExtensions()
    {
      public static void SomeSharedLogic(this ControllerBase controller)
      {
        controller.TempData["ShareLogicValue"] = "WhateveR";
      }
    }
