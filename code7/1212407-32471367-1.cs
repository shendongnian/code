	public partial class MainWindow : Window
	{
		private Image DragImage = null;
		public MainWindow()
		{
			InitializeComponent();
		}
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			// make sure we have an image
			var image = e.OriginalSource as Image;
			if (image == null)
				return;
			// make sure we've started dragging
			if (e.LeftButton != MouseButtonState.Pressed)
				return;
			DragDrop.DoDragDrop(image, image, DragDropEffects.Copy);
		}
		private void OnDragEnter(object sender, DragEventArgs e)
		{
			// make sure we have an image
			if (!e.Data.GetDataPresent(typeof(Image)))			
			{
				e.Effects = DragDropEffects.None;
				return;
			}
			// clone the image
			var image = e.Data.GetData(typeof(Image)) as Image;
			e.Effects = DragDropEffects.Copy;
			this.DragImage = new Image { Source = image.Source, Width=64, Height=64 };
			var position = e.GetPosition(this.targetGrid);
			this.DragImage.SetValue(Grid.MarginProperty, new Thickness(position.X-32, position.Y-32, 0, 0));
			this.DragImage.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Left);
			this.DragImage.SetValue(Grid.VerticalAlignmentProperty, VerticalAlignment.Top);
			this.DragImage.IsHitTestVisible = false; // so we don't try and drop it on itself
			
			// add it to the target grid
			targetGrid.Children.Add(this.DragImage);
		}
		private void OnDragMove(object sender, DragEventArgs e)
		{
			var position = e.GetPosition(this.targetGrid);
			this.DragImage.SetValue(Grid.MarginProperty, new Thickness(position.X - 32, position.Y - 32, 0, 0));
		}
		private void OnDragLeave(object sender, DragEventArgs e)
		{
			targetGrid.Children.Remove(this.DragImage);
			this.DragImage = null;
		}
		private void OnDrop(object sender, DragEventArgs e)
		{
			this.DragImage.IsHitTestVisible = true;
			this.DragImage = null;
		}
		
	}
