    Class Class_Name
    {
         Guid guid;
         HashTable hashtable_values;
         public void Start(string val1,string val2)
         {
              guid=Guid.NewGuid(); //for unique id for each session,
              //hastable and its values;
              // those are now already stored in the session 
         }
         public void End()
         {
            // send the hastable data to database;
            // hash_table has all the values still stored, process them at will
            // do realize that Session_End is not guaranteed to be called
            // so if you still want to store critical stuff in this phase
            // you might be missing data for some sessions    
         }
      }
