        ISQLFunction formatFunction =
            new SQLFunctionTemplate(NHibernateUtil.String, "FORMAT(?1, 'dddd dd MMM yyy', 'he-IL')");
		
		DateDTO dateDto = null;
        session.QueryOver<Date>()
            .Where(x => x.IsVisible != 0)
            .SelectList(lst => lst
                .Select(x => x.Id).WithAlias(() => dateDto.Id)
                .Select(Projections.SqlFunction(
                    formatFunction,
                    NHibernateUtil.String,
                    Projections.Property<Date>(x => x.DateTime))
                ).WithAlias(() => dateDto.Date))
            .TransformUsing(Transformers.AliasToBean<DateDTO>())
            .List<DateDTO>()
            .Dump();
    This generates the following SQL:
		SELECT
			this_.Id as y0_,
			FORMAT(this_.DateTime, 'dddd dd MMM yyy', 'he-IL') as y1_ 
		FROM
			Date this_ 
		WHERE
			not (this_.IsVisible = @p0);
    You may not even need to create a custom function if the NHibernate dialect you're using already supports it.
    I have a [blog post](http://www.andrewwhitaker.com/blog/2014/08/15/queryover-series-part-7-using-sql-functions/) about using SQL functions inside of your queries, if you're interested in going that route. (Full disclosure: this is my personal blog).
  
