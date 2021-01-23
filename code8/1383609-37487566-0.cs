            var fileBytes = wClient.DownloadData("3rd party api");;
            if (fileBytes == null) return;
            string filename = DateTime.Now.ToString("yyyy-MM-dd") + "-filename.docx";
            Response.Clear();
            Response.AddHeader("Content-Length", fileBytes.Length.ToString(CultureInfo.InvariantCulture));
            //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename)); // save file as attachment
            Response.AddHeader("Content-Disposition", string.Format("inline; filename={0}", filename)); // display inline in browser
            Response.AddHeader("Content-Type", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            Response.BinaryWrite(fileBytes);
            Response.Flush();
            Response.End();
