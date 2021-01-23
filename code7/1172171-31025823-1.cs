        List<String> wehaveadd = new List<String>();
        wehaveadd.Add("Jan");
        wehaveadd.Add("Feb"); // do all the months
        
       foreach(var item in wehaveadd){
         var path = "C:\\Desktop\\Month\\" + item;
         if (System.IO.Directory.Exists(path))
         {
          DropDownList1.Items.Add(item);
         }
       }
