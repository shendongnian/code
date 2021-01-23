            var query = Session.QueryOver<Company>()
                                    .JoinAlias(dbCompany => dbCompany.IndustryTypes, () => industryTypeAlias)
                                    .WhereRestrictionOn(() => industryTypeAlias.Name).IsIn(industryTypeNames)
                                    .SelectList(list => list
                                                            .SelectGroup(dbCompany => dbCompany.Id)
                                                            .SelectCount(dbCompany => industryTypeAlias.Name))
                                    .Where(Restrictions.Eq(Projections.Count<Company>(dbCompany => industryTypeAlias.Name), industryTypeNames.Length))
                                    .SelectList(list => list
                                                            .SelectGroup(dbCompany => dbCompany.Id).WithAlias(() => resIndustryType.Id)
                                               )
                                    .TransformUsing(Transformers.AliasToBean<DtoCompany>());
            var resultCompanyIdList = query.List().Select(company => company.Id).ToArray();
            var result = Session.QueryOver<DtoCompany>()
                                    .WhereRestrictionOn(dbCompany => dbCompany.Id)
                                    .IsIn(resultCompanyIdList);
            return result.List();
