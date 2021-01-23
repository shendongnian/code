       public static void trigger(string evt, object parameter){
            Action<object> item;
    
            if(event_list.TryGetValue(evt, out item)){
               if (item != null) {
                item.Invoke(parameter);
               }
            }
        }
