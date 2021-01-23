            int count = VisualTreeHelper.GetChildrenCount(contentControl);
            for (int i = 0; i < count; ++i)
            {
                DependencyObject d = VisualTreeHelper.GetChild(contentControl, i);
                if (d is RichTextBox)
                {
                    //...do your thing
                }
                //  recurse (if necessary)...
            }
