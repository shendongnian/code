    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace wfAutoClose {
      public class FormSubscriber : INotifyPropertyChanged, IDisposable {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IList<Form> _forms = new ObservableCollection<Form>();
        public IList<Form> Forms {
          get {
            return _forms;
          }
        }
        public int FormCount {
          get {
            return _forms.Count;
          }
        }
        private void RaisePropertyChanged(string propertyName) {
          var localEvent = PropertyChanged;
          if (localEvent != null) {
            localEvent.Invoke( this, new PropertyChangedEventArgs( propertyName: propertyName ) );
          }
        }
        private void OnChildFormClosed(object sender, FormClosedEventArgs e) {
          Forms.Remove( sender as Form );
        }
        private void SubscribeToFormClosedEvent(Form childForm) {
          childForm.FormClosed += OnChildFormClosed;
        }
        private void UnsubscribeFromFormClosedEvent(Form childForm) {
          childForm.FormClosed -= OnChildFormClosed;
        }
        private void OnChildFormCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
          if (e.OldItems != null) {
            foreach (var item in e.OldItems) {
              UnsubscribeFromFormClosedEvent( item as Form );
            }
          }
          if (e.NewItems != null) {
            foreach (var item in e.NewItems) {
              SubscribeToFormClosedEvent( item as Form );
            }
          }
          RaisePropertyChanged( "FormCount" );
        }
        public void Dispose() {
          ( Forms as INotifyCollectionChanged ).CollectionChanged -= OnChildFormCollectionChanged;
        }
        public FormSubscriber() {
          ( Forms as INotifyCollectionChanged ).CollectionChanged += OnChildFormCollectionChanged;
        }
      }
    }
