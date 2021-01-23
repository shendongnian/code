            for (int i = 0; i < listBox.Items.Count; i++)
            {
                var item = listBox.ItemContainerGenerator.ContainerFromItem(listBox.Items[i]) as ListBoxItem;
                var template = item.ContentTemplate as DataTemplate;
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(item);
                CheckBox myCheckBox = (CheckBox)template.FindName("checkBox", myContentPresenter);
                myCheckBox.IsChecked = true;
            }
