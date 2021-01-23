    var obj = new[] {
    	new { ID=1, StartDate=new DateTime(2016,1,15), EndDate=new DateTime(2016,2,15) },
    	new { ID=2, StartDate=new DateTime(2016,1,23), EndDate=new DateTime(2016,3,15) }
    };
    
    var result=obj.SelectMany(x=>
    	Enumerable.Range(0,int.MaxValue)
    		.Select(m=>new DateTime(x.StartDate.Year,x.StartDate.Month,1).AddMonths(m))
    		.TakeWhile(m=>m<x.EndDate)
    		.Select(m=>new {
    			x.ID,
    			//m.Year,
    			Month=m.ToString("MMM"),
    			Days=(x.EndDate.Year==m.Year && x.EndDate.Month==m.Month?x.EndDate.Day:DateTime.DaysInMonth(m.Year,m.Month))
    			-(x.StartDate.Year==m.Year && x.StartDate.Month==m.Month?x.StartDate.Day:0)
    		})
    );
