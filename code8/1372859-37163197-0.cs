    public class MyDataModelProvider
    {
    public List<MyDataModel> DataModelList { get; set; }
    MyDataModelProvider()
    {
        loadDataModelList();
    }
    private void LoadDataModel()
    {
        foreach (Cachobject c in Cache)
        {
            this.DataModelList.Add(new MyDataModel(c.valueA,c.valueB));
        }
    }
}
