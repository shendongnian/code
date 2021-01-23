    public class BoundObject
    {
       public void OnFrameLoadEnd (object sender, FrameLoadEndEventArgs e)
        {
            if(e.Frame.IsMain)
            {
                browser.ExecuteScriptAsync(@"
                 document.body.onmouseup = function()
                 {
                   bound.onSelected(window.getSelection().toString());
                 }
                ");
            }
        }
        public void OnSelected(string selected)
        {
            MessageBox.Show("The user selected some text [" + selected + "]");
        }
    }
