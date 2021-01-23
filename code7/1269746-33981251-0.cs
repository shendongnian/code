     `private int counter` =0;
      
         void OnTriggerEnter(...)
           {
             if(tag check)
                  {
                    counter ++;
                }
            }
    
        void OnTriggerExit(...)
        {
           if(tag check)
           {
             counter --;
           }
        }
    
        void OnCollisionEnter(...)
        {
          if(counter == 2)
          {
            ---- squeeze it
          }
          else
          {
            ---- make it normal maybe;
          }
         
        }
    
        void OnCollisionExit(...)
        {
           if(tag check)
            ---- make it normal maybe;
        }
