    List<Evaluator> originalEvals = db.Bids.Where(b => b.Id == entityId)
                    .Select(b => b.Evaluators)
                    .FirstOrDefault()
                    .ToList();
                foreach(Evaluator origEval in originalEvals)
                {
                    db.Entry(origEval).Reference(e => e.ClientUser).Load();
                    db.Entry(origEval).Collection(e => e.ItemGroups).Load();
                }
                foreach (Evaluator newEval in bid.Evaluators)
                {
                    Evaluator originalEval = originalEvals.Where(e => e.ClientUserId == newEval.ClientUserId).FirstOrDefault();
                    foreach (ItemGroup ig in originalEval.ItemGroups)
                    {
                        newEval.ItemGroups.Add(bid.ItemGroups.Where(g => g.Name == ig.Name).FirstOrDefault());
                    }
                }
