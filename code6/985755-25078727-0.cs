    int count = 0;
    
    dBUpdate.ForEach(dbu =>
    {
           dBUpdate1.Where(dbu1 => dbu1.Name.Equals(dbu.Name)).ToList().ForEach(dbu11 =>
           {
                  if (!dbu11.Color.Equals(dbu.Color) || !dbu11.Comments.Equals(dbu.Comments) || 
                            !dbu11.Management.Equals(dbu.Management))
                     {
                        count++;
                     }
            });
    
    });
    
    We can use linQ expressions also. 
