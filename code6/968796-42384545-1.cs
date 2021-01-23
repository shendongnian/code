    namespace Framework.UserApplication.CommonDialogs
    {
        sealed partial class TcpIpInputMaskType
        {
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
    
            /// <summary> 
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Component Designer generated code
    
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.pictureBox5 = new System.Windows.Forms.PictureBox();
                this.pictureBox4 = new System.Windows.Forms.PictureBox();
                this.pictureBox3 = new System.Windows.Forms.PictureBox();
                this.IP2 = new System.Windows.Forms.TextBox();
                this.IP3 = new System.Windows.Forms.TextBox();
                this.IP4 = new System.Windows.Forms.TextBox();
                this.IP1 = new System.Windows.Forms.TextBox();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
                this.SuspendLayout();
                // 
                // pictureBox5
                // 
                this.pictureBox5.Image = global::Framework.Properties.Resources.dot1;
                this.pictureBox5.Location = new System.Drawing.Point(87, 26);
                this.pictureBox5.Name = "pictureBox5";
                this.pictureBox5.Size = new System.Drawing.Size(5, 5);
                this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox5.TabIndex = 91;
                this.pictureBox5.TabStop = false;
                // 
                // pictureBox4
                // 
                this.pictureBox4.Image = global::Framework.Properties.Resources.dot1;
                this.pictureBox4.Location = new System.Drawing.Point(57, 25);
                this.pictureBox4.Name = "pictureBox4";
                this.pictureBox4.Size = new System.Drawing.Size(5, 5);
                this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox4.TabIndex = 90;
                this.pictureBox4.TabStop = false;
                // 
                // pictureBox3
                // 
                this.pictureBox3.Image = global::Framework.Properties.Resources.dot1;
                this.pictureBox3.Location = new System.Drawing.Point(29, 25);
                this.pictureBox3.Name = "pictureBox3";
                this.pictureBox3.Size = new System.Drawing.Size(5, 5);
                this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.pictureBox3.TabIndex = 89;
                this.pictureBox3.TabStop = false;
                // 
                // IP2
                // 
                this.IP2.Location = new System.Drawing.Point(32, 5);
                this.IP2.Name = "IP2";
                this.IP2.Size = new System.Drawing.Size(27, 20);
                this.IP2.TabIndex = 86;
                this.IP2.TextChanged += new System.EventHandler(this.IP1_TextChanged);
                this.IP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IP1_KeyPress);
                // 
                // IP3
                // 
                this.IP3.Location = new System.Drawing.Point(61, 5);
                this.IP3.Name = "IP3";
                this.IP3.Size = new System.Drawing.Size(27, 20);
                this.IP3.TabIndex = 87;
                this.IP3.TextChanged += new System.EventHandler(this.IP1_TextChanged);
                this.IP3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IP1_KeyPress);
                // 
                // IP4
                // 
                this.IP4.Location = new System.Drawing.Point(90, 5);
                this.IP4.Name = "IP4";
                this.IP4.Size = new System.Drawing.Size(27, 20);
                this.IP4.TabIndex = 88;
                this.IP4.TextChanged += new System.EventHandler(this.IP1_TextChanged);
                this.IP4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IP1_KeyPress);
                // 
                // IP1
                // 
                this.IP1.Location = new System.Drawing.Point(3, 5);
                this.IP1.Name = "IP1";
                this.IP1.Size = new System.Drawing.Size(27, 20);
                this.IP1.TabIndex = 85;
                this.IP1.TextChanged += new System.EventHandler(this.IP1_TextChanged);
                this.IP1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IP4_KeyDown);
                this.IP1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IP1_KeyPress);
                // 
                // TcpIpInputMaskType
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this.BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(this.pictureBox5);
                this.Controls.Add(this.pictureBox4);
                this.Controls.Add(this.pictureBox3);
                this.Controls.Add(this.IP2);
                this.Controls.Add(this.IP3);
                this.Controls.Add(this.IP4);
                this.Controls.Add(this.IP1);
                this.Name = "TcpIpInputMaskType";
                this.Size = new System.Drawing.Size(126, 31);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.PictureBox pictureBox5;
            private System.Windows.Forms.PictureBox pictureBox4;
            private System.Windows.Forms.PictureBox pictureBox3;
            private System.Windows.Forms.TextBox IP2;
            private System.Windows.Forms.TextBox IP3;
            private System.Windows.Forms.TextBox IP4;
            private System.Windows.Forms.TextBox IP1;
        }
    }
