    private static PictureBox[] pictureBoxArray;
    public static void ConvertGuiPBtoGuiPbArray(ContainerControl container)
    {
        pictureBoxArray = container.Controls.OfType<PictureBox>().OrderBy(x => x.Name).ToArray();
    }
    private void Main_Load(object sender, EventArgs e)
    {
        ConvertGuiPBtoGuiPbArray(this);//Or Whatever container like groupbox
    }
