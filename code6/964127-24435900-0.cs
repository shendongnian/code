    public string option_selected = "";
    public int check_count = 0;
   
    public void SearchElement(DependencyObject targeted_control)
    {
        var count = VisualTreeHelper.GetChildrenCount(targeted_control);   // targeted_control is the listbox
        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targeted_control, i);
                if (child is TextBlock) // specific/child control 
                {
                    TextBlock targeted_element = (TextBlock)child;
                    if (targeted_element.IsChecked == true)
                    {
                        if (targeted_element.Tag!= null)
                        {
                            
                            option_selected = targeted_element.Tag.ToString();
                        }
                                                return;
                    }
                }
                else
                {
                    SearchElement(child);
                }
            }
        }
        else
        {
            return;
        }
    }
