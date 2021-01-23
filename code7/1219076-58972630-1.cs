csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;
namespace System.Windows.Controls.Extensions
{
    public static class ListBoxExtensions
    {
        public static IObservable<List<T>> SelectionChanged<T>(this ListBox listBox)
        {
            return Observable.FromEventPattern<SelectionChangedEventHandler, SelectionChangedEventArgs>(
                eh => listBox.SelectionChanged += eh,
                eh => listBox.SelectionChanged -= eh)
                .Select(_ => listBox.SelectedItems.Cast<T>().ToList());
        }
    }
}
Then in your `Control`, bind the result to the `ViewModel` like this: 
csharp
    public partial class MyControl : UserControl, IViewFor<MyViewModel>
    {
        public MyControl()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                MyListView.SelectionChanged<MyItemViewModel>()
                    .Do(list => ViewModel.SelectedItems = list)
                    .SubscribeOn(RxApp.MainThreadScheduler)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe()
                    .DisposeWith(d);
            });
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = value as MyViewModel;
        }
        public MyViewModel ViewModel
        {
            get => DataContext as MyViewModel;
            set => DataContext = value;
        }
    }
