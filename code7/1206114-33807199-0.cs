        private async void WCF_ReceiveProductList(object sender, List<iSortData.PRODUCTS> e)
        {
            VScrollPosition["PRODUCT"] = dgProductContent.FirstDisplayedScrollingRowIndex;   
            HScrollPosition["PRODUCT"] = dgProductContent.FirstDisplayedScrollingColumnIndex;
            if (e.Count > 0)
            {
                await Task.Factory.StartNew(() => TaskBased_UpdateProductList(e)).ConfigureAwait(false);
            }
        }
         private void TaskBased_UpdateProductList(List<iSortData.PRODUCTS> productlist)
        {
            lock (_synclock)
            {
                this.ProductBindingList = MergeListWithBindingProductList(productlist, ProductBindingList);
            }
            dgProductContent.InvokeEx(ProductContent =>
                {
                    ProductContent.Refresh();
                    ProductContent.ClearSelection();
                });
                      
            SetGridScrollPositions(dgProductContent, "PRODUCT");
        }
       private Utility.Collections.ThreadedProductdingList<PRODUCT> MergeListWithBindingProductList(List<PRODUCT> list1, Utility.Collections.ThreadedProductdingList<PRODUCT> list2)
        {
            lock (_synclock)
            {
                var revdict = list1.ToDictionary(b => b.Name);
                if (list2.Count < 1)
                {
                    PRODUCTS[] list3 = revdict.Values.ToArray();
                    for (int x = 0, list3Length = list3.Length; x < list3Length; x++)    
                    {
                        list2.Add(list3[x]); // index out of range ??(impossible) but happens if not properly threaded i.e. no (_synclock).
                    }
                    
                }
                else
                {
                    for (int n = 0, list2Count = list2.Count; n < list2Count; n++)
                    {
                        if ((!String.IsNullOrEmpty(list2[n].Name)) && revdict.ContainsKey(list2[n].Name))
                        {
                            list2[n] = revdict[list2[n].Name];
                        }
                    }
                }
                return list2;
            }
        }
