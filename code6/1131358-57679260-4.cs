csharp
class MyViewModel
{
    public MyViewModel()
    {
        MyCollection = new ObservableCollection<MyModel>();
        Xamarin.Forms.BindingBase.EnableCollectionSynchronization(MyCollection, null, ObservableCollectionCallback);
    }
    public ObservableCollection<MyModel> MyCollection { get; }
    void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
    {
        lock (collection)
        {
            accessMethod?.Invoke();
        }
    }
}
