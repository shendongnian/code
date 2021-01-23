        namespace Plottings
        {
        public MultiSheetsPdf(){}
        public class MultiSheetsPdf
        {
            private string dwgFile, pdfFile, dsdFile, outputDir;
            private int sheetNum;
            private IEnumerable<Layout> layouts;
            private const string LOG = "publish.log";
            public MultiSheetsPdf(string pdfFile, IEnumerable<Layout> layouts)
            {
                Database db = HostApplicationServices.WorkingDatabase;
                this.dwgFile = db.Filename;
                this.pdfFile = pdfFile;
                this.outputDir = Path.GetDirectoryName(this.pdfFile);
                this.dsdFile = Path.ChangeExtension(this.pdfFile, "dsd");
                this.layouts = layouts;
            }
            public void Publish()
            {
                if (TryCreateDSD())
                {
                    Publisher publisher = AcAp.Publisher;
                    PlotProgressDialog plotDlg = new PlotProgressDialog(false, this.sheetNum, true);
                    publisher.PublishDsd(this.dsdFile, plotDlg);
                    plotDlg.Destroy();
                    File.Delete(this.dsdFile);
                }
            }
            private bool TryCreateDSD()
            {
                using (DsdData dsd = new DsdData())
                using (DsdEntryCollection dsdEntries = CreateDsdEntryCollection(this.layouts))
                {
                    if (dsdEntries == null || dsdEntries.Count <= 0) return false;
                    if (!Directory.Exists(this.outputDir))
                        Directory.CreateDirectory(this.outputDir);
                    this.sheetNum = dsdEntries.Count;
                    dsd.SetDsdEntryCollection(dsdEntries);
                    dsd.SetUnrecognizedData("PwdProtectPublishedDWF", "FALSE");
                    dsd.SetUnrecognizedData("PromptForPwd", "FALSE");
                    dsd.SheetType = SheetType.MultiDwf;
                    dsd.NoOfCopies = 1;
                    dsd.DestinationName = this.pdfFile;
                    dsd.IsHomogeneous = false;
                    dsd.LogFilePath = Path.Combine(this.outputDir, LOG);
                    PostProcessDSD(dsd);
                    return true;
                }
            }
            private DsdEntryCollection CreateDsdEntryCollection(IEnumerable<Layout> layouts)
            {
                DsdEntryCollection entries = new DsdEntryCollection();
                foreach (Layout layout in layouts)
                {
                    DsdEntry dsdEntry = new DsdEntry();
                    dsdEntry.DwgName = this.dwgFile;
                    dsdEntry.Layout = layout.LayoutName;
                    dsdEntry.Title = Path.GetFileNameWithoutExtension(this.dwgFile) + "-" + layout.LayoutName;
                    dsdEntry.Nps = layout.TabOrder.ToString();
                    entries.Add(dsdEntry);
                }
                return entries;
            }
            private void PostProcessDSD(DsdData dsd)
            {
                string str, newStr;
                string tmpFile = Path.Combine(this.outputDir, "temp.dsd");
                dsd.WriteDsd(tmpFile);
                using (StreamReader reader = new StreamReader(tmpFile, Encoding.Default))
                using (StreamWriter writer = new StreamWriter(this.dsdFile, false, Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        str = reader.ReadLine();
                        if (str.Contains("Has3DDWF"))
                        {
                            newStr = "Has3DDWF=0";
                        }
                        else if (str.Contains("OriginalSheetPath"))
                        {
                            newStr = "OriginalSheetPath=" + this.dwgFile;
                        }
                        else if (str.Contains("Type"))
                        {
                            newStr = "Type=6";
                        }
                        else if (str.Contains("OUT"))
                        {
                            newStr = "OUT=" + this.outputDir;
                        }
                        else if (str.Contains("IncludeLayer"))
                        {
                            newStr = "IncludeLayer=TRUE";
                        }
                        else if (str.Contains("PromptForDwfName"))
                        {
                            newStr = "PromptForDwfName=FALSE";
                        }
                        else if (str.Contains("LogFilePath"))
                        {
                            newStr = "LogFilePath=" + Path.Combine(this.outputDir, LOG);
                        }
                        else
                        {
                            newStr = str;
                        }
                        writer.WriteLine(newStr);
                    }
                }
                File.Delete(tmpFile);
            }
            [CommandMethod("PlotPdf")]
            public void PlotPdf()
            {
                Database db = HostApplicationServices.WorkingDatabase;
                short bgp = (short)Application.GetSystemVariable("BACKGROUNDPLOT");
                try
                {
                    Application.SetSystemVariable("BACKGROUNDPLOT", 0);
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        List<Layout> layouts = new List<Layout>();
                        DBDictionary layoutDict =
                            (DBDictionary)db.LayoutDictionaryId.GetObject(OpenMode.ForRead);
                        foreach (DBDictionaryEntry entry in layoutDict)
                        {
                            if (entry.Key != "Model")
                            {
                                layouts.Add((Layout)tr.GetObject(entry.Value, OpenMode.ForRead));
                            }
                        }
                        layouts.Sort((l1, l2) => l1.TabOrder.CompareTo(l2.TabOrder));
                        string filename = Path.ChangeExtension(db.Filename, "pdf");
                        MultiSheetsPdf plotter = new MultiSheetsPdf(filename, layouts);
                        plotter.Publish();
                        tr.Commit();
                    }
                }
                catch (System.Exception e)
                {
                    Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
                    ed.WriteMessage("\nError: {0}\n{1}", e.Message, e.StackTrace);
                }
                finally
                {
                    Application.SetSystemVariable("BACKGROUNDPLOT", bgp);
                }
            }
        }
    }
