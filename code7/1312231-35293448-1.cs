    private async void button1_Click(object sender, EventArgs e)
    {
        var itemList = new List<string>() { "Field1", "Field2", "Field3" }; // more than 50 items 
        Task.Run(() => Task.WhenAll(tasks));
    }
    public class WorkToDo
    {
     private string id;
     public WorkToDo(string id)
     {
         this.id = id;
     }
     public async Task<bool> StartWork()
     {
       var t1 = Calculate();
       var t2 = Analyze();
       var t3 = SomeToDo();
       
        //Assuming you need to do all this before you save
        // so wait for the all.
  
        await Task.WhenAll(t1,t2,t3);
        var result = await Save();
        return result;
    }
    private async Task<bool> Calculate()
    {
        //Some complex and time taking calculation will be here
        //Assuming here you have some DoAsync() method
        return true;
    }
    private async Task<bool> Analyze()
    {
        //Some complex and time taking calculation will be here
        return true;
    }
    private async Task<bool> SomeToDo()
    {
        //Some complex and time taking calculation will be here
        return true;
    }
    private async Task<bool> Save()
    {
        //Some complex and time taking calculation will be here
        return true;
    }
