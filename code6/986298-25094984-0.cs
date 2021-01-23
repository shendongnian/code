        string date = "1987/7/2";
        DateTime dt = Convert.ToDateTime(date);
      
        string diffDate =  MyDateTimeExtension.GetDiffDate(dt);       
        string[] words = diffDate.Split('/');
        
        if(Convert.ToInt32(words[1])== 0 && Convert.ToInt32(words[2])== 0){
                 Console.WriteLine("Today is your Birthday");
             }else{
              Console.WriteLine("You are " + words[0] + " Year/s " +  words[1] + " Month/s " +  words[2] + " Day/s");
             }
    
    }
