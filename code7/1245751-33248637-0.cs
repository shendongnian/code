    //add some using alias like this first
    //using i = System.Windows.Interactivity;
    public static class InteractionX 
    {
        public static readonly DependencyProperty TriggersProperty
            = DependencyProperty.RegisterAttached("Triggers", typeof(i.TriggerBase[]), 
              typeof(InteractionX), new PropertyMetadata(triggersChanged));
        public static i.TriggerBase[] GetTriggers(DependencyObject o){
            return o.GetValue(TriggersProperty) as i.TriggerBase[];
        }
        public static void SetTriggers(DependencyObject o, i.TriggerBase[] value)
        {
            o.SetValue(TriggersProperty, value);
        }
        static void triggersChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var triggers = e.NewValue as i.TriggerBase[];
            var currentTriggers = i.Interaction.GetTriggers(o);
            currentTriggers.Clear();
            foreach (var t in triggers)
            {
                t.Detach();
                currentTriggers.Add(t);
            }
        }
    }
