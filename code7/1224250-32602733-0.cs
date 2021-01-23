    internal class WidthButton : Button
    {
        private static Dictionary<Panel, List<Button>> _containers = new Dictionary<Panel, List<Button>>();
        public WidthButton()
        {
            this.Initialized += WidthButton_Initialized;
            this.SizeChanged += WidthButton_SizeChanged;
        }
        void WidthButton_Initialized(object sender, EventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(this) as Panel;
            if (parent == null) return;
            var thisButton = sender as Button;
            if (thisButton == null) return;
            if (!_containers.ContainsKey(parent))
            {
               _containers.Add(parent, new List<Button>()); 
            }
            if (!_containers[parent].Contains(thisButton))
            {
                _containers[parent].Add(thisButton);
            }
        }
        void WidthButton_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            var thisButton = sender as Button;
            if (thisButton == null) return;
            var containerPair = _containers.FirstOrDefault(pair => pair.Value.Contains(thisButton));
            if (containerPair.Value == null) return;
            var maxWidth = containerPair.Value.Max(btn => btn.ActualWidth);
            containerPair.Value.ForEach(btn => btn.Width = maxWidth);
        }
    }
