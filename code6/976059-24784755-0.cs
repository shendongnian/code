     public void ArrangeGrid()
        {          
             if(this.InvokeRequired) 
              { 
                 Action  arrange = ArrangeGrid ;  
                   this.Invoke(arrange); 
              }
              else
              {  
                //insert your code here  
              }
        }
