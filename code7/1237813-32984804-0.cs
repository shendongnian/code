    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    [assembly: TagPrefix("CustomeLable", "CsLable")]
    
    namespace ServerControl2
    {
        [DefaultProperty("Lable")]
        [DisplayName("Custome Lable")]
        [ToolboxData("<{0}:CustomeLable runat=server></{0}:CustomeLable>")]
        public class CustomeLable : CompositeControl
        {
            Panel p;
            Label lbl;
    
            [Bindable(true)]
            [Category("Appearance")]
            [DefaultValue("")]
            [Localizable(true)]
            public string Text
            {
                get
                {
                    return lbl.Text.Replace('*',' ').Trim();
                }
     
                set
                {
                    lbl.Text = value + " *";
                }
            }
    
            [Bindable(true)]
            [Category("Appearance")]
            [DefaultValue("Black")]
            [Localizable(true)]
            public Color TextColor
            {
                get
                {
                    return lbl.ForeColor;
                }
    
                set
                {
                    lbl.ForeColor = value;
                }
            }
    
            protected override void CreateChildControls()
            {
                Controls.Clear();
                p = new Panel();
                lbl = new Label();
                lbl.Text = "Custome Lable *";
                p.Controls.Add(lbl);
                base.CreateChildControls();
    
            }
            protected override void RecreateChildControls()
            {
                EnsureChildControls();
            }
            protected override void Render(HtmlTextWriter writer)
            {
                AddAttributesToRender(writer);
                lbl.RenderControl(writer);
            }
        }
    }
