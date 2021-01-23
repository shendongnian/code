    private static int? GetNextPhotoRateId(int photoRateId)
    {
            var result = photoRates
                // Just take the record having PhotoRateId bigger than the id received as parameter
                .Where(pr => pr.PhotoRateId > photoRateId)
                // And with Rate null
                .Where(pr => pr.Rate == null)
                // Select just the PhotoRateId
                .Select(pr => pr.PhotoRateId)
                // Order the result by Id
                .OrderBy(pr => pr)
                // Then take the first (the next one after the Id passed as parameter) 
                // or the default value (0)
                .FirstOrDefault();
            // If the result was 0, then return null
            if (result == 0)
            {
                return null;
            }
            // Otherwise return the result
            return result;
    }
