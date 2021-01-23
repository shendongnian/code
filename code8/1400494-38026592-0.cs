    public class ProductRetriver
    {
    List<int> ids = new List<int>();  // product ids
    List<string> prodNames = new List<string>();  // product names
    private TaskCompletionSource<List<string>> prodsTask;
    this.EventHandler += OnDownloadedProduct; 
    public static List<Task> TaskList = new List<Task>();
    Task<List<string>> async GetProducts(List<int> _ids)
    {
        ids = _ids;
        prodsTask = new TaskCompletionSource<List<string>>();
        
        foreach (var id in ids)
        {
           TaskList.Add(downloader.GetProduct(id));
        }
        Task.WaitAll(TaskList.ToArray());
        return prodNames;
    }
    //this event is fired once each product data is downloaded
    void OnDownloadedProduct(object sender, ProductDataArgs e)
    {
        // this is where I get product name and add it to the list
        string prodName = e.getProdName();
        prodNames.Add(prodName);
        if (prodNames.Count == ids.Count)
        {
            prodsTask.SetResult(prodNames);
        }
    }
}
