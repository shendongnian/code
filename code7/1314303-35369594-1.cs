    namespace TimeoutTest
    {
      partial class Form1
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
          this.BtStart = new System.Windows.Forms.Button();
          this.OutStatus = new System.Windows.Forms.TextBox();
          this.InConnections = new System.Windows.Forms.MaskedTextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.InInitialWait = new System.Windows.Forms.MaskedTextBox();
          this.InMultiplier = new System.Windows.Forms.MaskedTextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.BtCancel = new System.Windows.Forms.Button();
          this.label4 = new System.Windows.Forms.Label();
          this.OutLongestConnection = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // BtStart
          // 
          this.BtStart.Location = new System.Drawing.Point(13, 394);
          this.BtStart.Name = "BtStart";
          this.BtStart.Size = new System.Drawing.Size(75, 23);
          this.BtStart.TabIndex = 0;
          this.BtStart.Text = "Start";
          this.BtStart.UseVisualStyleBackColor = true;
          this.BtStart.Click += new System.EventHandler(this.BtStart_Click);
          // 
          // OutStatus
          // 
          this.OutStatus.Location = new System.Drawing.Point(13, 13);
          this.OutStatus.Multiline = true;
          this.OutStatus.Name = "OutStatus";
          this.OutStatus.ReadOnly = true;
          this.OutStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.OutStatus.Size = new System.Drawing.Size(766, 375);
          this.OutStatus.TabIndex = 1;
          // 
          // InConnections
          // 
          this.InConnections.Location = new System.Drawing.Point(180, 397);
          this.InConnections.Mask = "00";
          this.InConnections.Name = "InConnections";
          this.InConnections.Size = new System.Drawing.Size(22, 20);
          this.InConnections.TabIndex = 2;
          this.InConnections.Text = "10";
          this.InConnections.TextChanged += new System.EventHandler(this.InConnections_TextChanged);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(108, 400);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(66, 13);
          this.label1.TabIndex = 3;
          this.label1.Text = "Connections";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(289, 399);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(113, 13);
          this.label3.TabIndex = 5;
          this.label3.Text = "Initial Connection Wait";
          // 
          // InInitialWait
          // 
          this.InInitialWait.Location = new System.Drawing.Point(408, 396);
          this.InInitialWait.Mask = "00";
          this.InInitialWait.Name = "InInitialWait";
          this.InInitialWait.Size = new System.Drawing.Size(21, 20);
          this.InInitialWait.TabIndex = 4;
          this.InInitialWait.Text = "60";
          this.InInitialWait.TextChanged += new System.EventHandler(this.InConnections_TextChanged);
          // 
          // InMultiplier
          // 
          this.InMultiplier.Location = new System.Drawing.Point(262, 396);
          this.InMultiplier.Mask = "0";
          this.InMultiplier.Name = "InMultiplier";
          this.InMultiplier.Size = new System.Drawing.Size(21, 20);
          this.InMultiplier.TabIndex = 2;
          this.InMultiplier.Text = "2";
          this.InMultiplier.TextChanged += new System.EventHandler(this.InConnections_TextChanged);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(208, 400);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(48, 13);
          this.label2.TabIndex = 3;
          this.label2.Text = "Multiplier";
          // 
          // BtCancel
          // 
          this.BtCancel.Location = new System.Drawing.Point(13, 436);
          this.BtCancel.Name = "BtCancel";
          this.BtCancel.Size = new System.Drawing.Size(75, 23);
          this.BtCancel.TabIndex = 6;
          this.BtCancel.Text = "Cancel";
          this.BtCancel.UseVisualStyleBackColor = true;
          this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(451, 399);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(102, 13);
          this.label4.TabIndex = 7;
          this.label4.Text = "Longest Connection";
          // 
          // OutLongestConnection
          // 
          this.OutLongestConnection.AutoSize = true;
          this.OutLongestConnection.Location = new System.Drawing.Point(559, 399);
          this.OutLongestConnection.Name = "OutLongestConnection";
          this.OutLongestConnection.Size = new System.Drawing.Size(102, 13);
          this.OutLongestConnection.TabIndex = 8;
          this.OutLongestConnection.Text = "Longest Connection";
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(791, 582);
          this.Controls.Add(this.OutLongestConnection);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.BtCancel);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.InInitialWait);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.InMultiplier);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.InConnections);
          this.Controls.Add(this.OutStatus);
          this.Controls.Add(this.BtStart);
          this.Name = "Form1";
          this.Text = "Form1";
          this.Load += new System.EventHandler(this.Form1_Load);
          this.ResumeLayout(false);
          this.PerformLayout();
    
        }
    
        #endregion
    
        private System.Windows.Forms.Button BtStart;
        private System.Windows.Forms.TextBox OutStatus;
        private System.Windows.Forms.MaskedTextBox InConnections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox InInitialWait;
        private System.Windows.Forms.MaskedTextBox InMultiplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label OutLongestConnection;
      }
    }
    
    
