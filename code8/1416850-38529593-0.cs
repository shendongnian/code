            public static bool IsSimilarValuesExist(string value)
        {
            var result = false;
            double productSimilarity = 0;
            double publisherSimilarity = 0;
            List<string> products = FilterListWithFirstOrSecondCharacter(value, ServicesMail.GetAllProductNames());
            List<string> publishers = FilterListWithFirstOrSecondCharacter(value, ServicesMail.GetAllPublisherNames());
            IStringMetric metric = new Levenstein();
            foreach (var item in products)
            {
                if (metric.GetSimilarity(value, item) * 100 > 80)
                {
                    productSimilarity = metric.GetSimilarity(value, item) * 100;
                }
            }
            foreach (var item in publishers)
            {
                if (metric.GetSimilarity(value, item) * 100 > 80)
                {
                    publisherSimilarity = metric.GetSimilarity(value, item) * 100;
                }
            }
            var averageSimilarity = productSimilarity * publisherSimilarity / 2;
            if (averageSimilarity >= 80)
            {
                result = true;
            }
            return result;
        }
