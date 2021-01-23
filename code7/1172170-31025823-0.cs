        List<String> wehaveadd = new List<String>();
        wehaveadd.Add("Jan");
        wehaveadd.Add("Feb"); // do all the months
        //now check making recursive directory call and check in the list and path ends with wehaveadd key.
       foreach(var item in wehaveadd){
         var path = "C:\\Desktop\\Month\\" + item;
         if (System.IO.Directory.Exists(path))
         {
          DropDownList1.Items.Add(item);
         }
       }
