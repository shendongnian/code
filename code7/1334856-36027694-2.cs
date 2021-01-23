    using (var uow = new UnitOfWork(xsession.DataLayer))
                        {
                            BestData getSingleRec = new XPCollection<BestData>(uow, CriteriaOperator.Parse("[HomeTeamName]=? AND [GameDate]=?", tempStr5.ToString(), Convert.ToDateTime(gameDate))).FirstOrDefault();
 
                       
                                    getSingleRec.awayR = Convert.ToInt16(tempStr7);
                                    getSingleRec.homeR = Convert.ToInt16(tempStr8);
                                    getSingleRec.awayML = tempStr2;
                                    getSingleRec.homeML = tempStr3;
                           
                                getSingleRec.Save();
                                uow.CommitChanges();
                           
                        }
