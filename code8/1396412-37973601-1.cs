    using OToolsRibbon = Microsoft.Office.Tools.Ribbon;
    using System.Globalization;
    using System.Threading;
    using System.ComponentModel;
    
    using SysDiag = System.Diagnostics;
    
    namespace Pro_Wunderkiste4Excel
    {
        static class cs_RuntimeLocalizer4OfficeUI    //based on http://stackoverflow.com/questions/6980888/localization-at-runtime since relocalization after startup is not possible according to https://www.gittprogram.com/question/1159277_cultureinfo-currentculture.html
        {
            public static void ChangeCulture(OToolsRibbon.RibbonBase ri_Ribbon, string cultureCode)
            {
                CultureInfo culture = CultureInfo.GetCultureInfo(cultureCode);  //http://www.csharp-examples.net/culture-names/
                Thread.CurrentThread.CurrentUICulture = culture;
                ComponentResourceManager resources = new ComponentResourceManager(ri_Ribbon.GetType());
                foreach (OToolsRibbon.RibbonTab ri_Tab in ri_Ribbon.Tabs)    //based on http://www.devcomponents.com/kb2/?p=696
                {
                    resources.ApplyResources(ri_Tab, ri_Tab.Name, culture);
                    foreach (OToolsRibbon.RibbonGroup ri_TabGroups in ri_Tab.Groups)    //based on http://stackoverflow.com/questions/7824125/better-way-to-programmatically-lock-disable-multiple-ui-controls-on-ribbon-bar
                    {
                        resources.ApplyResources(ri_TabGroups, ri_TabGroups.Name, culture);
                        foreach (OToolsRibbon.RibbonControl ri_TabGroupsCtrl in ri_TabGroups.Items)
                        {
                            SysDiag.Debug.Print(ri_TabGroupsCtrl.Name);
                            resources.ApplyResources(ri_TabGroupsCtrl, ri_TabGroupsCtrl.Name, culture);
                        }
                    }
                }
            }
        }
    }
