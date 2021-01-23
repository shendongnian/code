    public class MyForm
    {
       private MyDataSourceType myDataSource = null;
       private void SetDataModel()
       {
           myDataSource = Build<Model>(query);
           repeater.DataSource = myDataSource
           repeater.DataBind();
       }
       private void FilterDataSet()
       {
           IEnumerable<MyDataType> enumerated = myDataSource.GetEnumerator();
           var filteredDataSource; // Filter Logic here
           repeater.DataSource = filteredDataSource;
           repeater.DataBind();
       }
    }
