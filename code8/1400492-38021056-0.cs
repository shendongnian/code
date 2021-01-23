     public class ProductRetriver
    {
        List<int> ids = new List<int>();
        List<string> prodNames = new List<string>();  //list to fill with prod names once they are downloaded
        private TaskCompletionSource<List<string>> prodsTask;
            this.EventHandler += OnDownloadedProduct; //event fired once each product is downloaded
            Task<List<string>> async GetProducts(List<int> _ids)
        {
            ids = _ids;
            prodsTask = new TaskCompletionSource<List<string>>();
            foreach (var id in ids)
            {
                downloader.GetProduct(id);  //fires OnDownloadedProduct once product is downloaded
            }
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
