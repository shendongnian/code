        private async void ReadPDF(object sender, EventArgs e)
         {
            String sdCardPath = Environment.ExternalStorageDirectory.AbsolutePath;
            String fullpath = Path.Combine(sdCardPath, "folder/" + "file.pdf");
            var creator = new PdfHelper();
            string filePath = await creator.PCLReadFile(fullpath);
            Uri pdfPath = Uri.FromFile(new File(filePath));
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(pdfPath, "application/pdf");
            intent.SetFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
