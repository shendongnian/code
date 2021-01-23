    /// <summary>
    /// An implementation of <seealso cref="ObservableCollection{T}"/> that provides the ability to suppress
    /// change notifications. In sub-classes that allows performing batch work and raising notifications 
    /// on completion of work. Standard usage takes advantage of this feature by providing AddRange method.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class ObservableList<T> : ObservableCollection<T>
    {
        #region Fields
        private readonly Queue<PropertyChangedEventArgs> _notifications = new Queue<PropertyChangedEventArgs>();
        private readonly Queue<NotifyCollectionChangedEventArgs> _collectionNotifications = new Queue<NotifyCollectionChangedEventArgs>();
        private int _notificationSupressionDepth;
        #endregion
        public ObservableList()
        {
        }
        public ObservableList(IEnumerable<T> collection)
            : base(collection)
        {
        }
        public void AddRange(IEnumerable<T> list)
        {
            using (SupressNotifications())
            {
                foreach (var item in list)
                {
                    Add(item);
                }
            }
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void RemoveRange(IEnumerable<T> list)
        {
            using (SupressNotifications())
            {
                foreach (var item in list)
                {
                    Remove(item);
                }
            }
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void ReplaceRange(IEnumerable<T> list)
        {
            using (SupressNotifications())
            {
                Clear();
                foreach (var item in list)
                {
                    Add(item);
                }
            }
            OnPropertyChanged("Count");
            OnPropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (_notificationSupressionDepth == 0)
            {
                base.OnCollectionChanged(e);
            }
            else
            {
                //We cant filter duplicate Collection change events as this will break how UI controls work. -LC
                _collectionNotifications.Enqueue(e);
            }
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (_notificationSupressionDepth == 0)
            {
                base.OnPropertyChanged(e);
            }
            else
            {
                if (!_notifications.Contains(e, NotifyEventComparer.Instance))
                {
                    _notifications.Enqueue(e);
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected IDisposable QueueNotifications()
        {
            _notificationSupressionDepth++;
            return Disposable.Create(() =>
                                         {
                                             _notificationSupressionDepth--;
                                             TryNotify();
                                         });
        }
        protected IDisposable SupressNotifications()
        {
            _notificationSupressionDepth++;
            return Disposable.Create(() =>
            {
                _notificationSupressionDepth--;
            });
        }
        private void TryNotify()
        {
            if (_notificationSupressionDepth == 0)
            {
                while (_collectionNotifications.Count > 0)
                {
                    var collectionNotification = _collectionNotifications.Dequeue();
                    base.OnCollectionChanged(collectionNotification);
                }
                while (_notifications.Count > 0)
                {
                    var notification = _notifications.Dequeue();
                    base.OnPropertyChanged(notification);
                }
            }
        }
    }
