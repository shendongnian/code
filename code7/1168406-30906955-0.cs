    public Form1()
        {
            InitializeComponent();              
            progressBar1.Visible = false;
            progressBar2.Visible = false;
        }
    
         Random rnd = new Random();
         private void random1()
         {
            int t = rnd.Next(200);
            label1.Text = t.ToString();
            this.Refresh();
         }
         private void random2()
         {
            int t = rnd.Next(1500);
            label2.Text = t.ToString();
         }
         private void button1_Click_1(object sender, EventArgs e)
         {
            int i;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 4000;
            progressBar1.Visible = true;
            for (i = 0; i <= 4000; i++)
            {
                progressBar1.Value = i;
                int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) /(double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
                using (Graphics gr = progressBar1.CreateGraphics())
                {
                    gr.DrawString(percent.ToString() + "%",
                        SystemFonts.MessageBoxFont,
                        Brushes.Black,
                        new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                            SystemFonts.MessageBoxFont).Width / 2.0F),
                        progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                            SystemFonts.MessageBoxFont).Height / 2.0F)));
                }
            }
            progressBar1.Visible = false;         
            random1();
           
                progressBar2.Minimum = 0;
                progressBar2.Maximum = 3000;
                progressBar2.Visible = true;
                for (i = 0; i <= 3000; i++)
                {
                    progressBar2.Value = i;
                    int percent = (int)(((double)(progressBar2.Value - progressBar2.Minimum) / (double)(progressBar2.Maximum - progressBar2.Minimum)) * 100);
                    using (Graphics gr = progressBar2.CreateGraphics())
                    {
                        gr.DrawString(percent.ToString() + "%",
                            SystemFonts.MessageBoxFont,
                            Brushes.Black,
                            new PointF(progressBar2.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.MessageBoxFont).Width / 2.0F),
                            progressBar2.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                                SystemFonts.MessageBoxFont).Height / 2.0F)));
                    }
                }
                progressBar2.Visible = false;
                random2();           			
			
         }
