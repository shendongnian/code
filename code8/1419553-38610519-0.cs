    var allData = (from t1 in table1
                    join t2 in table2
                    on t1.Column1 equals t2.Column1
                    join t3 in table3
                    on t1.Column1.ToString() equals t3.Column1
                    join t4 in table4
                    on t3.Column1 equals t4.Column1
                    join t5 in table5
                    on new { X1 = t4.Column1, X2 = t4.Column2 }
                    equals new { X1 = t5.Column1, X2 = t5.Column1 }
                    where t1.Column1 == t4.Column1
                    select ....
