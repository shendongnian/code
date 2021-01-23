      private static void TotalOutcome(List<Prenumerator> prenumerators, List<Publication> publications)
            {
                foreach (Publication publication in publications)
                {
                    foreach (Prenumerator prenumerator in prenumerators.Where(prenumerator => prenumerator.PublicationCode == publication.Code))
                    {
                        publication.Earnings += prenumerator.Count * publication.MonthPrice;
                    }
                }
            }
