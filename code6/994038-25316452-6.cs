    public enum ToolEnum
    {
        Draw = 1,
        Rubber = 2,
        Fill = 3,
        ......
    }
    
    public class Form2
    {
         public delegate void OnToolChanged(ToolEnum newTool);
         public event OnToolChanged ToolChanged;
    
         ....
    
         protected override palette_Click(object sender, EventArgs e)
         {
             // Code that retrieves the tool clicked....
             ToolEnum choosenTool = GetTool();
             // If someone is interested to know when the user changes tool 
             // then it has subscribed to the ToolChanged event passing an 
             // appropriate event handler 
             if(ToolChanged != null)
                 ToolChanged(choosenTool);
         }
    }
