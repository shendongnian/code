    var query = from T1 in table1
        join t2 in table2 on T1.ID_T1 equals t2.ID_t2
        join t3 in **table3** on new { 
                                       ID = T1.ID_T1, 
                                       substring = t2.Other_t2_field
                                     } equals new 
                                     {
                                       ID = v.ID_t3,
                                       substring = Microsoft.VisualBasic.Strings.Left(t2.Another_t3_field, 5)
                                     }
        where (Conditions)
        select new 
        {
            (My fields)
        };
