    public static void EnumVisuals(Visual argVisual, Button toModifyButton)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(argVisual); i++)
            {
                Visual childVisual = (Visual) VisualTreeHelper.GetChild(argVisual, i);
                if (childVisual is Button)
                {
                    var button = childVisual as Button;
                    button.MouseEnter += (sender, eventArgs) =>
                    {
                        toModifyButton.Content = "Get the Help text from database if you want";
                    };
                }
                EnumVisuals(childVisual, toModifyButton);
            }
        }
