    btnGeneratePDF = new Button();
    btnGeneratePDF.Text = "Generate PDF";
    btnGeneratePDF.UseSubmitBehavior = true; // I don't know if this is necessary
    btnGeneratePDF.Click += new EventHandler(btnGenPDF_Click);
    btnGeneratePDF.Visible = false;
    this.Controls.Add(btnGeneratePDF);
