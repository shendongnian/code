            if (enemyHits.Length > 0)
            {
                List<EnemyIdentifier> EnemyIdentitys = new List<EnemyIdentifier>();
                foreach (RaycastHit2D hit in enemyHits)
                {
                    EnemyIdentitys.Add(hit.transform.GetComponent<EnemyIdentifier>());
                }
                var groupedEnemyIdentitys = EnemyIdentitys
                    .GroupBy(x => x.Owner)
                    .Select(grp => grp.ToList())
                    .ToList();
            }
       
