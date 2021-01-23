        private static Expression<Func<HIProduct, bool>> CheckWildCardPosition(string serie)
        {
            char[] wildCard = new char[] { SqlWildCardAnyValue };
            if (serie.StartsWith(SqlWildCardAnyValue.ToString()))
            {
                if (serie.EndsWith(SqlWildCardAnyValue.ToString()))
                {
                    return hip => hip.ProductId.Series.Contains(serie.Trim(wildCard));
                }
                return hip => hip.ProductId.Series.EndsWith(serie.TrimStart(wildCard));
            }
            else if (serie.EndsWith(SqlWildCardAnyValue.ToString()))
            {
                return hip => hip.ProductId.Series.StartsWith(serie.TrimEnd(wildCard));
            }
            else
            {
                string[] split = serie.Split(wildCard);
                return hip => hip.ProductId.Series.StartsWith(split[0]) && hip.ProductId.Series.EndsWith(split[1]);
            }
        }
