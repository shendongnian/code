    var groups = from work in ctx.Works // the work table
                 group work // we want to group whole work "rows"
                    // we are grouping by project id and subproject id
                    by new { ProjId = work.ProjId, SubProjId = work.SubProjId } 
                    into g // and we are calling the grouping 'g'
                 select g; // select the group
    // example of doing something with the groupings
    foreach (var group in groups)
    {
       var key = group.Key; // gets a { ProjId, SubProjId } tuple
       foreach (var work in group)
       {
          // each work is a row in the Work-table
       }
    }
