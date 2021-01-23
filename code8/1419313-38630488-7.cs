    partial class ImageWithText
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
            this.ChampionImage = new System.Windows.Forms.PictureBox();
            this.ChamptionName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChampionImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ChampionImage
            // 
            this.ChampionImage.Location = new System.Drawing.Point(5, 5);
            this.ChampionImage.Margin = new System.Windows.Forms.Padding(5);
            this.ChampionImage.Name = "ChampionImage";
            this.ChampionImage.Size = new System.Drawing.Size(120, 120);
            this.ChampionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChampionImage.TabIndex = 0;
            this.ChampionImage.TabStop = false;
            // 
            // label1
            // 
            this.ChamptionName.AutoSize = true;
            this.ChamptionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChamptionName.Location = new System.Drawing.Point(33, 130);
            this.ChamptionName.Name = "label1";
            this.ChamptionName.Size = new System.Drawing.Size(73, 13);
            this.ChamptionName.TabIndex = 1;
            this.ChamptionName.Text = "SampleText";
            // 
            // ImageWithText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ChamptionName);
            this.Controls.Add(this.ChampionImage);
            this.Name = "ImageWithText";
            this.Size = new System.Drawing.Size(130, 150);
            this.Load += new System.EventHandler(this.ImageWithText_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChampionImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.PictureBox ChampionImage;
        private System.Windows.Forms.Label ChamptionName;
