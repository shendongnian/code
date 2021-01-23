	using Spire.Doc;
	using Spire.Doc.Documents;
	namespace Word2Image
	{
		/// 
		/// Interaction logic for MainWindow.xaml
		/// 
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
			private void button1_Click(object sender, RoutedEventArgs e)
			{
				Document doc = new Document("sample.docx", FileFormat.Docx2010);
				BitmapSource[] bss = doc.SaveToImages(ImageType.Bitmap);
				for (int i = 0; i < bss.Length; i++)
				{
					SourceToBitmap(bss[i]).Save(string.Format("img-{0}.png", i));
				}
			}
			private Bitmap SourceToBitmap(BitmapSource source)
			{        
				Bitmap bmp;
				using (MemoryStream ms = new MemoryStream())
				{
					PngBitmapEncoder encoder = new PngBitmapEncoder();
					encoder.Frames.Add(BitmapFrame.Create(source));
					encoder.Save(ms);
					bmp = new Bitmap(ms);
				}
				return bmp;
			}
		}
	}
