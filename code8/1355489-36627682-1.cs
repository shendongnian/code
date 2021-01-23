    static void Main(string[] args)
    {
    	string sFile = "ExcelOpenXmlWithImage.xlsx";
    	if (File.Exists(sFile))
    	{
    		File.Delete(sFile);
    	}
    	BuildWorkbook(sFile);
    }
    private static void BuildWorkbook(string filename)
    {
    	try
    	{
    		using (SpreadsheetDocument xl = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook))
    		{
    			WorkbookPart wbp = xl.AddWorkbookPart();
    			WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
    			Workbook wb = new Workbook();
    			FileVersion fv = new FileVersion();
    			fv.ApplicationName = "Microsoft Office Excel";
    			Worksheet ws = new Worksheet();
    			SheetData sd = new SheetData();
    			string sImagePath = "polymathlogo.png";
    			DrawingsPart dp = wsp.AddNewPart<DrawingsPart>();
    			ImagePart imgp = dp.AddImagePart(ImagePartType.Png, wsp.GetIdOfPart(dp));
    			using (FileStream fs = new FileStream(sImagePath, FileMode.Open))
    			{
    				imgp.FeedData(fs);
    			}
    			NonVisualDrawingProperties nvdp = new NonVisualDrawingProperties();
    			nvdp.Id = 1025;
    			nvdp.Name = "Picture 1";
    			nvdp.Description = "polymathlogo";
    			DocumentFormat.OpenXml.Drawing.PictureLocks picLocks = new DocumentFormat.OpenXml.Drawing.PictureLocks();
    			picLocks.NoChangeAspect = true;
    			picLocks.NoChangeArrowheads = true;
    			NonVisualPictureDrawingProperties nvpdp = new NonVisualPictureDrawingProperties();
    			nvpdp.PictureLocks = picLocks;
    			NonVisualPictureProperties nvpp = new NonVisualPictureProperties();
    			nvpp.NonVisualDrawingProperties = nvdp;
    			nvpp.NonVisualPictureDrawingProperties = nvpdp;
    			DocumentFormat.OpenXml.Drawing.Stretch stretch = new DocumentFormat.OpenXml.Drawing.Stretch();
    			stretch.FillRectangle = new DocumentFormat.OpenXml.Drawing.FillRectangle();
    			BlipFill blipFill = new BlipFill();
    			DocumentFormat.OpenXml.Drawing.Blip blip = new DocumentFormat.OpenXml.Drawing.Blip();
    			blip.Embed = dp.GetIdOfPart(imgp);
    			blip.CompressionState = DocumentFormat.OpenXml.Drawing.BlipCompressionValues.Print;
    			blipFill.Blip = blip;
    			blipFill.SourceRectangle = new DocumentFormat.OpenXml.Drawing.SourceRectangle();
    			blipFill.Append(stretch);
    			DocumentFormat.OpenXml.Drawing.Transform2D t2d = new DocumentFormat.OpenXml.Drawing.Transform2D();
    			DocumentFormat.OpenXml.Drawing.Offset offset = new DocumentFormat.OpenXml.Drawing.Offset();
    			offset.X = 0;
    			offset.Y = 0;
    			t2d.Offset = offset;
    			Bitmap bm = new Bitmap(sImagePath);
    			//http://en.wikipedia.org/wiki/English_Metric_Unit#DrawingML
    			//http://stackoverflow.com/questions/1341930/pixel-to-centimeter
    			//http://stackoverflow.com/questions/139655/how-to-convert-pixels-to-points-px-to-pt-in-net-c
    			DocumentFormat.OpenXml.Drawing.Extents extents = new DocumentFormat.OpenXml.Drawing.Extents();
    			extents.Cx = (long)bm.Width * (long)((float)914400 / bm.HorizontalResolution);
    			extents.Cy = (long)bm.Height * (long)((float)914400 / bm.VerticalResolution);
    			bm.Dispose();
    			t2d.Extents = extents;
    			ShapeProperties sp = new ShapeProperties();
    			sp.BlackWhiteMode = DocumentFormat.OpenXml.Drawing.BlackWhiteModeValues.Auto;
    			sp.Transform2D = t2d;
    			DocumentFormat.OpenXml.Drawing.PresetGeometry prstGeom = new DocumentFormat.OpenXml.Drawing.PresetGeometry();
    			prstGeom.Preset = DocumentFormat.OpenXml.Drawing.ShapeTypeValues.Rectangle;
    			prstGeom.AdjustValueList = new DocumentFormat.OpenXml.Drawing.AdjustValueList();
    			sp.Append(prstGeom);
    			sp.Append(new DocumentFormat.OpenXml.Drawing.NoFill());
    			DocumentFormat.OpenXml.Drawing.Spreadsheet.Picture picture = new DocumentFormat.OpenXml.Drawing.Spreadsheet.Picture();
    			picture.NonVisualPictureProperties = nvpp;
    			picture.BlipFill = blipFill;
    			picture.ShapeProperties = sp;
    			Position pos = new Position();
    			pos.X = 0;
    			pos.Y = 0;
    			Extent ext = new Extent();
    			ext.Cx = extents.Cx;
    			ext.Cy = extents.Cy;
    			AbsoluteAnchor anchor = new AbsoluteAnchor();
    			anchor.Position = pos;
    			anchor.Extent = ext;
    			anchor.Append(picture);
    			anchor.Append(new ClientData());
    			WorksheetDrawing wsd = new WorksheetDrawing();
    			wsd.Append(anchor);
    			Drawing drawing = new Drawing();
    			drawing.Id = dp.GetIdOfPart(imgp);
    			wsd.Save(dp);
    			ws.Append(sd);
    			ws.Append(drawing);
    			wsp.Worksheet = ws;
    			wsp.Worksheet.Save();
    			Sheets sheets = new Sheets();
    			Sheet sheet = new Sheet();
    			sheet.Name = "Sheet1";
    			sheet.SheetId = 1;
    			sheet.Id = wbp.GetIdOfPart(wsp);
    			sheets.Append(sheet);
    			wb.Append(fv);
    			wb.Append(sheets);
    			xl.WorkbookPart.Workbook = wb;
    			xl.WorkbookPart.Workbook.Save();
    			xl.Close();
    		}
    	}
    	catch (Exception e)
    	{
    		Console.WriteLine(e.ToString());
    		Console.ReadLine();
    	}
    }
