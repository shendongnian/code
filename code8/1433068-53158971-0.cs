    public partial class saveImage : Window
    {
        public saveImage()
        {
            InitializeComponent();
        }
        OpenFileDialog Op = new OpenFileDialog();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Op.Title = "image selection";
            Op.Filter = "JPG(.jpg)|*.jpg|PNG(.png)|*.png|JPEG(.jpeg)|*.jpeg";
            if (Op.ShowDialog() == true)
            {
                img1.Source = new BitmapImage(new Uri(Op.FileName));
            }
            
           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PersonAccountingdbEntities db = new PersonAccountingdbEntities();
            tbl_Setting set = new tbl_Setting();
            set.Image1 = File.ReadAllBytes(Op.FileName);
            db.tbl_Setting.Add(set);
            db.SaveChanges();
            MessageBox.Show("image has been saved");
        }
       
    }
}
