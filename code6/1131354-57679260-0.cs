csharp
class MyViewModel
{
    public MyViewModel()
    {
        Xamarin.Forms.BindingBase.EnableCollectionSynchronization(MyCollection, new object(), ObservableCollectionCallback);
    }
    public ObservableRangeCollection<MyModel> MyCollection { get; } = new ObservableRangeCollection<MyModel>();
    void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
    {
        lock (context)
        {
            accessMethod?.Invoke();
        }
    }
}
