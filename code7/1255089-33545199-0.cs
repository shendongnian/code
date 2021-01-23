    public class Parent : Form
    {
         var popup = new Popup();
         var result = popup.ShowDialog();
         if(result == DialogResult.OK)
         {
            this.BackgroundImage = popup.Image;
         }
    }
    public class Popup : Form
    {
        private void SelectImage()
        {
            Image = pictureBoxBackground.Image;
        }
        public string Image {get;set;}
    }
