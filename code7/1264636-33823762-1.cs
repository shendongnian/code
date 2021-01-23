    private static int? GetNextPhotoRateId(int photoRateId)
    {
        return photoRates
            // Just take the record having PhotoRateId bigger than the id received as parameter
            .Where(pr => pr.PhotoRateId > photoRateId)
            // And with Rate null
            .Where(pr => pr.Rate == null)
            // Order the result by Id
            .OrderBy(pr => pr.PhotoRateId)
            // Then take the first (the next one after the Id passed as parameter) 
            // or the default value (null)
            .FirstOrDefault();
    }
