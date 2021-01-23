          using (XLWorkbook wb = new XLWorkbook())
	        {
		IXLWorksheet WorkSheet = new IXLWorksheet();
		  string LogoPath = Server.MapPath("~/App_Themes/Images/logonew.png");
          System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(LogoPath);
          if (bitmap != null)
             {
                var stream = new System.IO.MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
                if (stream != null)
                {
                    stream.Position = 0;
                    XLPicture pic = new XLPicture
                    {
                         NoChangeAspect = true,
                         NoMove = true,
                         NoResize = true,
                         ImageStream = stream,
                         Name = "Logo",
                         EMUOffsetX = 4,
                         EMUOffsetY = 6
                    };
                    XLMarker fMark = new XLMarker
                    {
						ColumnId = 1,
                        RowId = 1
                     };
                     pic.AddMarker(fMark);
                    WorkSheet.AddPicture(pic);
                 }
              }
			  
			   Response.Clear();
               Response.Buffer = true;
               Response.Charset = "";
               Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
               Response.AddHeader("content-disposition", "attachment;filename=test.xls");
               using (MemoryStream MyMemoryStream = new MemoryStream())
               {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
               }
		
	}
