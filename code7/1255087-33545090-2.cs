    public class FormB : Form
    {
        //[...]Stuff
        private Image image;
        public Image SelectedImage
        {
            get
            {
                return image;
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            image = [Whatever Image variable that you want to return];
            Close();
        }
    }
