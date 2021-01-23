        static void Main(string[] args)
        {
            IAcadApplication acadApp;
            IAcadDocument thisdrawing;
            acadApp = Marshal.GetActiveObject("AutoCAD.Application.20") as AcadApplication;
            acadApp.Visible = true;
            thisdrawing = acadApp.ActiveDocument;
            thisdrawing.Activate();
            string str = "_CopyBase" + char.ConvertFromUtf32(13) + "0,0,0" + char.ConvertFromUtf32(13) + "M" + char.ConvertFromUtf32(13) + "G" + char.ConvertFromUtf32(13) + "QWERT" + "\n" + char.ConvertFromUtf32(13);
            thisdrawing.SendCommand(str);
            string dwgTempPath = "acad.dwt";
            IAcadDocument newThisdrawing = acadApp.Documents.Add(dwgTempPath);
            //Instead of the path below, use your full path, formatted correctly
            newThisdrawing.SaveAs(@"C:\Acad\Test.dwg", thisdrawing.Application.Preferences.OpenSave.SaveAsType, null);
 
            newThisdrawing.Regen(AcRegenType.acActiveViewport);
            newThisdrawing.Activate();
            string comStr = "pasteclip" + "\n" + "0,0" + "\n";
            newThisdrawing.SendCommand(comStr);
        }
