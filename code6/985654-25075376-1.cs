        static class ProtfolioFactory
        {
            static public Portfolio BuildPortfolio(string[] values)
            {
                var portfolio  = new Portfolio();
                if (values != null)
                {
                    portfolio.Value1 = values.ElementAtOrDefault(0);
                    portfolio.Value2 = values.ElementAtOrDefault(1);
                    portfolio.Value3 = values.ElementAtOrDefault(2);
                    portfolio.Method = values.ElementAtOrDefault(3);
                    portfolio.Period = values.ElementAtOrDefault(4);
                }
                return portfolio;
            }
        }
