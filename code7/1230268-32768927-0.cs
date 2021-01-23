     private void SectionReport1_ReportStart(object sender, EventArgs e)
        {
            GrapeCity.ActiveReports.SectionReportModel.CustomControl cc;
            MyControl myc = new MyControl();           
            cc = new GrapeCity.ActiveReports.SectionReportModel.CustomControl(myc.GetType());
            cc.Location = new PointF(1f, 1f);
            cc.Size = new SizeF(4f, 4f);            
            this.detail.Controls.Add(cc);
        }
