    from a in ctx.As
    join b in ctx.Bs on a.AId equals b.AId into bgrp // group join -- put matching Bs
                                                     // into a group "bgrp".
    from b in bgrp.DefaultIfEmpty()                  // from DefaultIfEmpty() -- if the group
                                                     // has any rows, return them. otherwise,
                                                     // return a single row with the
                                                     // entity's default value (null).
    select new
    {
        a.AId,
        b.BId
    }
    
