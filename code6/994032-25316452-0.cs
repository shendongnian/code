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
             ToolEnum choosenTool = GetTool();
             if(ToolChanged != null)
                 ToolChanged(choosenTool);
         }
    }
