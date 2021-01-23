    Task<List<string>> async GetProducts(List<int> ids)
        {
            List<string> prodNames = new List<string>();
            downloder.EventHandler += (s, e) => {
                string prodName = e.getProdName();
                prodNames.Add(prodName);
                if (prodNames.Count == ids.Count)
                {
                    prodsTask.SetResult(prodNames);
                }
            };
            foreach (var id in ids)
            {
                downloader.GetProduct(id);  //fires OnDownloadedProduct once product is downloaded
            }
            return prodNames;
        }
