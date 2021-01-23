    public static class GlobalEvents
    {
        static readonly ClassHandlerSubject s_TextBoxGotFocus = new ClassHandlerSubject(typeof(TextBox), UIElement.GotFocusEvent);
        public static IObservable<RoutedEventArgs> TextBoxGotFocus => s_TextBoxGotFocus.Events;
        class ClassHandlerSubject
        {
            readonly Lazy<Subject<RoutedEventArgs>> m_Subject;
            public IObservable<RoutedEventArgs> Events => m_Subject.Value;
            public ClassHandlerSubject(Type classType, RoutedEvent routedEvent) =>
                m_Subject = new Lazy<Subject<RoutedEventArgs>>(() =>
                {
                    EventManager.RegisterClassHandler(classType, routedEvent, new RoutedEventHandler(OnEventReceived));
                    return new Subject<RoutedEventArgs>();
                });
            private void OnEventReceived(object sender, RoutedEventArgs e) => m_Subject.Value.OnNext(e);
        }
    }
