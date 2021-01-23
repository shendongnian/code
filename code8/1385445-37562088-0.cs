    private void InitializeComponent()
    {
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.AutoSize = true;
        this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.tableLayoutPanel1.ColumnCount = 3;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
        this.tableLayoutPanel1.RowCount = 1;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanel1.Size = new System.Drawing.Size(443, 10);
        this.tableLayoutPanel1.TabIndex = 1;
        // 
        // Dashboard
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.BackColor = System.Drawing.Color.Transparent;
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "Dashboard";
        this.Size = new System.Drawing.Size(443, 208);
        this.Load += new System.EventHandler(this.Dashboard_Load);
        this.MouseEnter += new System.EventHandler(this.Dashboard_MouseEnter);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
