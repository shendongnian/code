             var cnt = 0;
            foreach (Prenumerator prenumerator in prenumerators)
            {
                if (prenumerator.PublicationCode == publication.Code)
                {
                    cnt += prenumerator.Count;
                }
            }
            publication.Earnings = cnt * publication.MonthPrice;
