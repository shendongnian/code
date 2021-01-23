    using System.Windows.Forms;
    using System.Globalization;
    using System.Threading;
    using System.ComponentModel;
    
    namespace Pro_Wunderkiste4Excel
    {
        static class cs_RuntimeLocalizer4Forms //based on https://stackoverflow.com/questions/6980888/localization-at-runtime and https://stackoverflow.com/questions/3558406/how-to-change-language-at-runtime-without-layout-troubles
        {
            
            public static void ChangeCulture(Form frm, string cultureCode)
            {
                CultureInfo culture = CultureInfo.GetCultureInfo(cultureCode);  //http://www.csharp-examples.net/culture-names/
    
                Thread.CurrentThread.CurrentUICulture = culture;
    
                ComponentResourceManager resources = new ComponentResourceManager(frm.GetType());
    
                ApplyResourceToControl(resources, frm, culture);
                resources.ApplyResources(frm, "$this", culture);
            }
    
            private static void ApplyResourceToControl(ComponentResourceManager res, Control control, CultureInfo lang)
            {
                if (control.GetType() == typeof(MenuStrip))  // See if this is a menuStrip
                {
                    MenuStrip strip = (MenuStrip)control;
    
                    ApplyResourceToToolStripItemCollection(strip.Items, res, lang);
                }
    
                foreach (Control c in control.Controls) // Apply to all sub-controls
                {
                    ApplyResourceToControl(res, c, lang);
                    res.ApplyResources(c, c.Name, lang);
                }
    
                // Apply to self
                res.ApplyResources(control, control.Name, lang);
            }
    
            private static void ApplyResourceToToolStripItemCollection(ToolStripItemCollection col, ComponentResourceManager res, CultureInfo lang)
            {
                for (int i = 0; i < col.Count; i++)     // Apply to all sub items
                {
                    ToolStripItem item = (ToolStripMenuItem)col[i];
    
                    if (item.GetType() == typeof(ToolStripMenuItem))
                    {
                        ToolStripMenuItem menuitem = (ToolStripMenuItem)item;
                        ApplyResourceToToolStripItemCollection(menuitem.DropDownItems, res, lang);
                    }
    
                    res.ApplyResources(item, item.Name, lang);
                }
            }
        }
    }
