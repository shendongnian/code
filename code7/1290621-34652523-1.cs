    case eFilterOperator.Contains:
                        {
                            NHibernate.Criterion.Conjunction conjunction = new NHibernate.Criterion.Conjunction();
                            conjunction.Add(NHibernate.Criterion.Expression.IsNotNull(_filter.Member)); 
                            conjunction.Add(NHibernate.Criterion.Expression.InsensitiveLike(_filter.Member, _filter.Value.ToString(), NHibernate.Criterion.MatchMode.Anywhere));
                            return conjunction;
                        }
