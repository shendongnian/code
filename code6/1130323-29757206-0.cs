    public partial class btnControl : UserControl
        {
            public Label label = new Label();
            public TextBox box = new TextBox();
    
            public btnControl()
            {
                this.label = new System.Windows.Forms.Label();
                this.box = new System.Windows.Forms.TextBox();
                this.SuspendLayout();
                // 
                // label
                // 
                this.label.AutoSize = true;
                this.label.ForeColor = System.Drawing.Color.White;
                this.label.Location = new System.Drawing.Point(4, 7);
                this.label.Name = "label";
                this.label.Size = new System.Drawing.Size(35, 13);
                this.label.TabIndex = 0;
                this.label.Text = "label";
                // 
                // box
                // 
                this.box.Location = new System.Drawing.Point(110, 3);
                this.box.Name = "box";
                this.box.Size = new System.Drawing.Size(31, 20);
                this.box.TabIndex = 1;
                this.box.Enabled = false;
                // 
                // btnControl
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.Blue;
                this.Controls.Add(this.box);
                this.Controls.Add(this.label);
                this.Name = "btnControl";
                this.Size = new System.Drawing.Size(144, 26);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }
