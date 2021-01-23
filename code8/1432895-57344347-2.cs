    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout(); 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 462);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
            int borderThickness = 5;
            Color borderColor = Color.Cyan;
            CustomPanel panel1 = new CustomPanel(borderThickness, borderColor);
            panel1.BackColor = Color.Yellow;
            panel1.Location = new Point(400, 30);
            panel1.Size = new Size(300, 300);
            panel1.Parent = this;
            this.Controls.Add(panel1);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Text = "this is the text whose center I want to align";
            label1.Location = new Point(panel1.Location.X + panel1.Width / 2 - label1.Width / 2, 80);
            if (this.Controls.Contains(label1))
            {
                label1.BringToFront();
            }
        }
        private Label label1;
    }
