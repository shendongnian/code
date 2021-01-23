csharp
class MyViewModel
{
    public MyViewModel()
    {
        Xamarin.Forms.BindingBase.EnableCollectionSynchronization(MyCollection, null, ObservableCollectionCallback);
    }
    public ObservableRangeCollection<MyModel> MyCollection { get; } = new ObservableRangeCollection<MyModel>();
    void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
    {
        lock (collection)
        {
            accessMethod?.Invoke();
        }
    }
}
