    public partial class Form1 : Form
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 417);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<PictureBox> picturebox = new List<PictureBox>();
            DirectoryInfo directoryInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            var recentpics = directoryInfo.GetFiles("*.jpg*", SearchOption.AllDirectories).OrderByDescending(t => t.LastWriteTime).Take(4).ToList();
            var y = 10;
            foreach (var file in recentpics)
            {
                var pb = new PictureBox();                
                pb.Location = new Point(picturebox.Count * 120 + 20, y);
                pb.Size = new Size(100, 120);                
                pb.Image = Image.FromFile(file.FullName);
                this.Controls.Add(pb);
                picturebox.Add(pb);
            }
        }
    }
