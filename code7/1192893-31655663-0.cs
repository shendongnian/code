    Class ResultItem {
    	int Index {get;set;}
    	int Id {get;set;}
    }
    
    IEnumerable<ResultItem> GetRecipeFruitList(IEnumerable<FruitItem> tblFruitList, IEnumerable<RecipeLine> recipeLineList) {
        var result = new List<ResultItem>();
        foreach (FruitItem fruitItem in tblFruitList) {
            var match = recipeLineList.FirstOrDefault((r) => r.PossibleNames.Contains(fruitItem.Name));
            if (match != null) {
                result.Add(new ResultItem() {Index = match.Index, Id = fruitItem.Id});
            }
        }
        return result;
    }
