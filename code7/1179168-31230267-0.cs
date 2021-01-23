    foreach ( dynamic item1 in response_list)
         {
             if (item1 != null)
             {
                 discussions_cnt_new.Add(new Students() { Name = item1.Name, Age = item1.Age });  
             }
         }
