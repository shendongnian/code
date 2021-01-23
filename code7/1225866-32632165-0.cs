    public void AddEqualCompareFilter(string fieldName, string fieldValue)
        {
            if (String.IsNullOrEmpty(fieldValue) == false) {
                if (Filter != null) {
                    Filter = Filter & Builders<TranslationsDocument>.Filter.Eq(fieldName, fieldValue);
                }
                else {
                    FilterCount++;
                    Filter = Builders<TranslationsDocument>.Filter.Eq(fieldName, fieldValue);
                }
            }
        }
