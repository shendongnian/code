        private OxyPlot.WindowsForms.PlotView plot1;
        private OxyPlot.WindowsForms.PlotView plot2;
        private OxyPlot.WindowsForms.PlotView plot3;
             private void InitializeComponent()
        {
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.plot2 = new OxyPlot.WindowsForms.PlotView();
            this.plot3 = new OxyPlot.WindowsForms.PlotView();
            this.SuspendLayout();
            // 
            // plot1
            // 
            //this.plot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot1.Location = new System.Drawing.Point(0, 0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(300, 300);
            this.plot1.TabIndex = 0;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plot2
            // 
            //this.plot2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot2.Location = new System.Drawing.Point(300, 0);
            this.plot2.Name = "plot2";
            this.plot2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot2.Size = new System.Drawing.Size(300, 300);
            this.plot2.TabIndex = 0;
            this.plot2.Text = "plot2";
            this.plot2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // plot3
            // 
            //this.plot3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot3.Location = new System.Drawing.Point(900, 600 );
            this.plot3.Name = "plot3";
            this.plot3.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot3.Size = new System.Drawing.Size(300,300);
            this.plot3.TabIndex = 0;
            this.plot3.Text = "plot3";
            this.plot3.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot3.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot3.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 900);
            this.Controls.Add(this.plot3);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.plot2);
            this.Name = "Form1";
            this.Text = "plot3 Score";
            this.ResumeLayout(false);
        }
