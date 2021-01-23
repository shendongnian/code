            private static void UpdateItems(NexusEditor editor)
        {
            editor.Items.Clear();
            var sourceB = editor.SourceB as IEnumerable;
            if (sourceB != null)
            {
                foreach (object obj in sourceB)
                {
                    var item = new NexusItem() { Item = obj, Background = new SolidColorBrush(Colors.Green) };
                    editor.Items.Add(item);
                }
            }
            var sourceA = editor.SourceA as IEnumerable;
            if (sourceA != null)
            {
                foreach (object obj in sourceA)
                {
                    var item = new NexusItem() { Item = obj, Background = new SolidColorBrush(Colors.Red) };
                    editor.Items.Add(item);
                }
            }
        }
