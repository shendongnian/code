            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                var directory = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory, "pdf").ToString();
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
    
                var path = Path.Combine(directory, "myTestFile.pdf");
    
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
    
                var fs = new FileStream(path, FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                document.Add(new Paragraph("Hello World"));
                document.Close();
                writer.Close();
                fs.Close();
    
                Java.IO.File file = new Java.IO.File(path);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(Android.Net.Uri.FromFile(file), "application/pdf");
                StartActivity(intent);
            }
