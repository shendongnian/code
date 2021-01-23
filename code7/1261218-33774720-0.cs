    if (!dictionaryType.HasItems())
            {
                DictionaryDto newForEmptyList = new DictionaryDto();
                List<DictionaryDto> newList = new List<DictionaryDto>();
                newForEmptyList.FeatureId = type;
                newForEmptyList.ProductId = productId;
                newForEmptyList.Value = "";
                newForEmptyList.Id = -1;
                newList.Add(newForEmptyList);
                dictionaryType = newList.ToArray();
            }
