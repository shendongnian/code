            BlockingCollection<Tuple<Guid, int>> c = new BlockingCollection<Tuple<Guid,int>>();
            Task.Factory.StartNew(() => {
                using (IEnumerator<Tuple<Guid, int>> iter = global.NarrowItemResultRepository.Narrow_GetCount_Batch(userData.NarrowItems, dicId2Nar.Values).GetEnumerator()) {
                    while (iter.MoveNext()) {
                        c.Add(iter.Current);
                    }
                    c.CompleteAdding();
                }
            });
