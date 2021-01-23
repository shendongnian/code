    All_Items.GroupBy(category => category.Category).Select(key =>
                    {
                        var maxCategoryStartDate = key.Max(value => value.StartDate);
                        return key.Select(v => {
                            if (DateTime.Equals(v.StartDate, maxCategoryStartDate))
                            {
                                v.EndDate = maxEndDate;
                            }
                            else
                            {
                                v.EndDate = maxCategoryStartDate - TimeSpan.FromDays(1);
                            }
                            return v;
                            });
                    }
                ).SelectMany(x => x);
