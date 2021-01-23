    EntryPointForLogic() {
        Object obj = CreateObject();
        List<Action<object>> actions = new List<Action<object>>()
        { 
             UpdateObj1,UpdateObj2,UpdateObj3
        };
        
 
        for(int i =0; i<actions.Count; i++)
        {
            try
            {
                 actions[i](obj);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured in update nr {i}");
            }
        }
    }
