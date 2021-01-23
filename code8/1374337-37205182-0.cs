     System.Threading.Timer timer;
     int i=-1;
   
    public string[] words = new string[]{"add", "ado", "age", "ago", "aid", "ail", "aim", "air", "and", "any", "ape", "apt", "arc", "are", "ark", "arm",
            "art", "ash", "ask", "auk", "awe", "awl", "aye", "bad", "bag", "ban", "bat", "bee", "boa", "ear", "eel", "eft",
            "far", "fat", "fit", "lee", "oaf", "rat", "tar", "tie"};
      private async void button1_Click(object sender, EventArgs e)
     {
     timer = new System.Threading.Timer(timer_Tick, null, 0, 100); //Time delay 100
     }
     private void timer_Tick(Object state)
            {                
                    try
                    {
                       
                        i++;
                        this.Invoke((MethodInvoker)delegate
                        {
                             label1.Text = words[i];
                            
                        });  
    
                    }
                    catch (Exception ex)
                    {                      
                    }
                    finally
                    {                      
                    }
                
            }
