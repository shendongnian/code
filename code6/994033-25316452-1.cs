     Form2 f = new Form2(this);
     f.ToolChanged += myToolChangedHandler;
     ....
     public void myToolChangedHandler(ToolEnum newTool)
     {
         if(newTool == ToolEnum.Fill)
         {
             ... adapt for the fill operation ...
         }
     }
