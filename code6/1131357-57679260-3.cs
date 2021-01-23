csharp
class MyViewModel
{
    public MyViewModel()
    {
        MyCollection = new ObservableRangeCollection<MyModel>();
        Xamarin.Forms.BindingBase.EnableCollectionSynchronization(MyCollection, null, ObservableCollectionCallback);
    }
    public ObservableRangeCollection<MyModel> MyCollection { get; }
    void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
    {
        lock (collection)
        {
            accessMethod?.Invoke();
        }
    }
}
