            var q = session.Query<User>().Where(x => x.Id == id);
            var lst = new List<IEnumerable>
            {
                q.FetchMany(x => x.Characters).ToFuture(),
                q.Fetch(x=>x.UpdateableData).ToFuture(),
                session.QueryOver<User>().Where(x => x.Id == id)
                    .Fetch(x=>x.Characters).Eager
                    .Fetch(x => x.Characters.First().SmartChallengeTrackers).Eager
                    .Future()
            };
            var r = session.QueryOver<User>().Where(x => x.Id == id)
                .TransformUsing(Transformers.DistinctRootEntity)
                .Future();
            
            foreach (IEnumerable el in lst)
            {
                foreach (object o in el)
                {
                }
            }
            return r.ToArray();
