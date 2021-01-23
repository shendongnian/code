    if (ExampleA.CurrentInstance != null)
    {
         var button = ExampleA.CurrentInstance.FindName("OKButton") as Button;
         if (button != null)
         {
             button.IsEnabled = true;
         }
    }
