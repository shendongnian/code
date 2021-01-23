    public class EventLogBox : RichTextBox
    {
        public EventLogBox()
        {
        }
        static EventLogBox()
        {
            RichTextBox.IsReadOnlyProperty.OverrideMetadata(
                typeof(EventLogBox),
                new FrameworkPropertyMetadata(true));
            RichTextBox.VerticalScrollBarVisibilityProperty.OverrideMetadata(
                typeof(EventLogBox),
                new FrameworkPropertyMetadata(ScrollBarVisibility.Visible));
            RichTextBox.FontFamilyProperty.OverrideMetadata(
                typeof(EventLogBox),
                new FrameworkPropertyMetadata(new FontFamily("Courier New")));
        }
        private void AddItem(string pEntry)
        {
            Paragraph a = new Paragraph();
            Run messageRun = new Run(pEntry);
            a.Inlines.Add(messageRun);
            this.Document.Blocks.Add(a);
            this.ScrollToEnd();
        }
        private void LoadNewItems()
        {
            this.Document.Blocks.Clear();
            foreach (string entry in DataSource)
            {
                this.AddItem(entry);
            }
        }
        /// <summary>
        ///     The source of content (EventLogEntrys)
        /// </summary>
        public IEnumerable<string> DataSource
        {
            get
            {
                return (IEnumerable<string>)GetValue(DataSourceProperty);
            }
            set
            {
                SetValue(DataSourceProperty, value);
            }
        }
        /// <summary>
        ///     Using a DependencyProperty as the backing store for <see cref="DataSource"/>.
        ///     This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register
            (
                "DataSource",
                typeof(IEnumerable<string>), typeof(EventLogBox),
                new PropertyMetadata
                (
                    new ObservableQueue<string>(),
                    new PropertyChangedCallback(DataSourcePropertyChanged)
                ),
                new ValidateValueCallback(IsValidDataSourceProperty)
            );
        /// <summary>
        /// We also ned to impliment the INotifyCollectionChanged interface
        /// in order for everything to work properly.
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        private static bool IsValidDataSourceProperty(object pValue)
        {
            return pValue is INotifyCollectionChanged;
        }
        /// <summary>
        /// Callback when the DataSourceProperty changes. Setup the new
        /// CollectionChanged events, etc.
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pArgs"></param>
        private static void DataSourcePropertyChanged(DependencyObject pSender,
            DependencyPropertyChangedEventArgs pArgs)
        {
            EventLogBox s = ((EventLogBox)pSender);
            ((INotifyCollectionChanged)s.DataSource).CollectionChanged -=
                new NotifyCollectionChangedEventHandler(
                    s.DataSource_CollectionChanged);
            ((INotifyCollectionChanged)s.DataSource).CollectionChanged +=
                new NotifyCollectionChangedEventHandler(
                    s.DataSource_CollectionChanged);
            s.LoadNewItems();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pArgs"></param>
        private void DataSource_CollectionChanged(object pSender,
            NotifyCollectionChangedEventArgs pArgs)
        {
            IList n = pArgs.NewItems;
            switch (pArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (string cle in pArgs.NewItems)
                        {
                            AddItem(cle);
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        for (int i = pArgs.OldStartingIndex;
                             i < pArgs.OldItems.Count; i++)
                        {
                            this.Document.Blocks.Remove(this.Document.Blocks.ElementAt(i));
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {
                        break;
                    }
            }
        }
    }
