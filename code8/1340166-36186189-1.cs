    var groupedObjectList = from DataRow r in ds.Tables[0].Rows
                                    group r by r.Field<string>("ID") into g
                                    select new { EventDate = g.Key, Items = g.Select(i => new { Title = i.Field<string>("Title"), Location = i.Field<string>("Location") }).ToList() };
            rptCalendar.DataSource = groupedObjectList;
            rptCalendar.DataBind();
