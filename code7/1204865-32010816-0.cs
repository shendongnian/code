    private void ClearAllComboboxes()
        {
            List<ComboBox> comboBoxes = new List<ComboBox>();
            GetLogicalChildCollection<ComboBox>(container, comboBoxes);
            comboBoxes.ForEach(combobox => combobox.SelectedIndex = -1);
        }
        private static void GetLogicalChildCollection<T>(DependencyObject parent,List<T> logicalCollection) where T : DependencyObject
        {
           
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }
