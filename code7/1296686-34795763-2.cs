    namespace testforms
    {
        public partial class Form1
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
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.comboBox1 = new System.Windows.Forms.ComboBox();
                this.comboBox2 = new System.Windows.Forms.ComboBox();
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // comboBox1
                // 
                this.comboBox1.FormattingEnabled = true;
                this.comboBox1.Location = new System.Drawing.Point(36, 30);
                this.comboBox1.Name = "comboBox1";
                this.comboBox1.Size = new System.Drawing.Size(121, 21);
                this.comboBox1.TabIndex = 0;
                // 
                // comboBox2
                // 
                this.comboBox2.FormattingEnabled = true;
                this.comboBox2.Location = new System.Drawing.Point(36, 91);
                this.comboBox2.Name = "comboBox2";
                this.comboBox2.Size = new System.Drawing.Size(121, 21);
                this.comboBox2.TabIndex = 1;
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(36, 162);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 2;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click_1);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 261);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.comboBox2);
                this.Controls.Add(this.comboBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            internal System.Windows.Forms.ComboBox comboBox1;
            internal System.Windows.Forms.ComboBox comboBox2;
            private System.Windows.Forms.Button button1;
        }
    }
