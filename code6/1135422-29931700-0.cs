    // code-behind
    protected override void OnPreRender(EventArgs e)
    {
        // 1. code put here will be executed first
    
        // now we call the base class' version, which will then raise the
        // PreRender event
        base.OnPreRender(e);
        
        // 3. code put here will be executed last
    }
    // markup       
    <script language="C#" runat="server">
        void Page_PreRender()
        {
            // 2. code put here will be executed second
    
        }
    </script>
