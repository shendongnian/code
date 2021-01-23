         using (TestEntities context = new TestEntities())
        {
              string searchText = "rem";
              ObjectParameter total = new ObjectParameter("out",typeof(int));
    
              List<sp_SoInfoDocs_Result> lst = context.sp_SoInfoDocs(searchText, 1, 10, total).ToList();
    
              foreach (var item in lst)
              {
                Console.WriteLine(item.jobName + " " + item.oDate + " " + item.serverName + " " + item.startTime + " " + item.endTime);
                  
              }
               Console.ReadLine();
        } 
