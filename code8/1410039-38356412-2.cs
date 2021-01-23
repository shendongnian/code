        private List<IReportRelationMapping> GetAvailableRelation(List<IReportRelationMapping> relationsMappings, string belongsTo)
        {
            List<IReportRelationMapping> pathToTarget = new List<IReportRelationMapping>();
            var requiredRelation = relationsMappings.Where(x => x.LocalRelation.TableAlias == belongsTo || x.ForeignRelation.TableAlias == belongsTo).FirstOrDefault();
            if (requiredRelation != null)
            {
                //Handle the top level
                pathToTarget.Add(requiredRelation);
            } else {
                //At this point we know there is no match on the top level, lets check the nested level
                var relatedRelations = new List<IReportRelationMapping>();
            
                foreach (var relationsMapping in relationsMappings)
                {
                    if (relationsMapping.RelatedThrough != null)
                    {
                        //Add the path in between previous and next
                        pathToTarget.Add(relationsMapping);
                        relatedRelations.Add(relationsMapping.RelatedThrough);
                    }
                }
                if (relatedRelations.Any())
                {
                    //Now we know there is at least one more nested level that we need to check
                    var subPathsToTarget = GetAvailableRelation(relatedRelations, belongsTo);
                  if (subPathsToTarget.Any())
                    {
                        //prepend the current items to the path
                        pathToTarget = pathToTarget.Concat(subPathsToTarget).ToList();
                    }
                    else
                    {
                        //At this point we know we reach the final node and the item was not found.
                        pathToTarget.Clear();
                    }
                }
            }
            
            return pathToTarget;
        }
