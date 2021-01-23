    public class DynamicCbs : Control
    {
      public int CtrlsCount { get; set; }
      public List<CheckBox> lstCheckBoxs;
      /// decleration of controls must be in the OnInit since the next stage of the page life cycle is to connect whatever came back from the client to the server
       protected override void OnInit(EventArgs e)
      {
           base.OnInit(e);
           lstCheckBoxs = new List<CheckBox>();
           for (int i = 0; i < CtrlsCount; i++) 
           {
              string id = "DynamicCbs" + i;
              CheckBox cbx = new CheckBox() 
              {
                 ID = id,
                 Text = "i am " + id 
              };
              lstCheckBoxs.Add(cbx);
              //add controls to control tree
               this.Controls.Add(cbx); 
           }
       }
       /// here you must build ur html
        public override void RenderControl(HtmlTextWriter writer) 
       {
           writer.RenderBeginTag(HtmlTextWriterTag.Table);
           writer.RenderBeginTag(HtmlTextWriterTag.Thead);
           foreach (var cbx in lstCheckBoxs)
           {
              writer.RenderBeginTag(HtmlTextWriterTag.Th); 
              cbx.RenderControl(writer);
              writer.RenderEndTag();
           }
           writer.RenderEndTag();//thead
            writer.RenderEndTag();//table
        }
    }
