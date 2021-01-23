    float gamma = 1f ;
    float contrast = 1f;
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        gamma = 1f * trackBar1.Value / 100f;
        label1.Text = gamma.ToString("#0.00");
        pictureBox1.Image = ApplyGamma(originalImage, gamma, contrast);
    }
    private void trackBar2_Scroll(object sender, EventArgs e)
    {
        contrast = 1f * trackBar2.Value / 1000f;
        label2.Text = contrast.ToString("#0.00");
        pictureBox1.Image = ApplyGamma(originalImage, gamma, contrast);
    }
