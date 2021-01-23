    private void InitializeComponent()
    {
        this.panel1 = new System.Windows.Forms.Panel();
        this.webBrowser1 = new System.Windows.Forms.WebBrowser();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.Controls.Add(this.webBrowser1);
        this.panel1.Location = new System.Drawing.Point(47, 149);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(200, 100);
        this.panel1.TabIndex = 0;
        // 
        // webBrowser1
        // 
        this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.webBrowser1.Location = new System.Drawing.Point(0, 0);
        this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
        this.webBrowser1.Name = "webBrowser1";
        this.webBrowser1.Size = new System.Drawing.Size(200, 100);
        this.webBrowser1.TabIndex = 0;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 261);
        this.Controls.Add(this.panel1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);
    }
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.WebBrowser webBrowser1;
