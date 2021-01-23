    public static class MyBinder
    {
        private const string LoadedEventName = "Loaded";
        private const string UnloadedEventName = "Unloaded";
        /// <summary>
        /// Automatically attach Loaded, Unloaded events.
        /// </summary>
        public static void AddCustomBinding(object viewModel, DependencyObject view)
        {
            if (view is FrameworkElement && viewModel is ViewModelBase)
            {
                EnsureLoading((ViewModelBase)viewModel, (FrameworkElement)view);
            }
        }
        private static void EnsureLoading(ViewModelBase model, FrameworkElement view)
        {
            Preconditions.CheckArgumentNotNull(model, "model");
            Preconditions.CheckArgumentNotNull(view, "view");
            Interactivity.TriggerCollection triggers = Interactivity.Interaction.GetTriggers(view);
            Ensure(triggers, view, LoadedEventName, ViewModelBase.LoadMethodName);
            Ensure(triggers, view, UnloadedEventName, ViewModelBase.UnloadMethodName);
        }
        private static void Ensure(Interactivity.TriggerCollection triggers, DependencyObject view, string eventName, string methodName)
        {
            if (IsEnsured(triggers, eventName, methodName))
                return; // already ensured
            string binding = string.Format("[{0}] = [{1}()]", eventName, methodName);
            triggers.Add(Parser.Parse(view, binding).Single());
        }
        private static bool IsEnsured(Interactivity.TriggerCollection triggers, string eventName, string methodName)
        {
            Interactivity.EventTrigger trigger = triggers.OfType<Interactivity.EventTrigger>().FirstOrDefault(a => a.EventName == eventName);
            if (trigger == null)
                return false;
            else
                return trigger.Actions.OfType<ActionMessage>().Any(a => a.MethodName == methodName && a.Parameters.Count == 0);
        }
    }
