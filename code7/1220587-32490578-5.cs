    private IEnumerable<string> ArticleLine(double quantity, string name, double sellPrice, double total)
    {
        List<string> quantityChunks = quantity.ToString("#,##0.00").SplitIntoChunks(maxCharArticleQuantity);
        List<string> nameChunks = name.SplitIntoChunks(maxCharArticleName);
        List<string> sellPriceChunks = sellPrice.ToString("#,##0.00").SplitIntoChunks(maxCharArticleSellPrice);
        List<string> totalChunks = total.ToString("#,##0.00").SplitIntoChunks(maxCharArticleTotal);
        int maxLines = (new List<int>() { quantityChunks.Count, 
                                          nameChunks.Count,
                                          sellPriceChunks.Count,
                                          totalChunks.Count }).Max();
        for (int i = 0; i < maxLines; i++)
        {
      
            lines.Add(String.Format("{0}{1}{2}{3}",
                                    quantityChunks.Count > i ?
                                    quantityChunks[i].PadLeft(maxCharArticleQuantity) :
                                    String.Empty.PadLeft(maxCharArticleQuantity),
                                    nameChunks.Count > i ?
                                    nameChunks[i].PadLeft(maxCharArticleName) :
                                    String.Empty.PadLeft(maxCharArticleName, ' '),
                                    sellPriceChunks.Count > i ?
                                    sellPriceChunks[i].PadLeft(maxCharArticleSellPrice) :
                                    String.Empty.PadeLeft(maxCharArticleSellPrice),
                                    totalChunks.Count > i ?
                                    totalChunks[i].PadLeft(maxCharArticleTotal) :
                                    String.Empty.PadLeft(maxCharArticleTotal));                                    
        }
   
        return lines;     
    }
