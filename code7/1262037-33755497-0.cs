    public partial class Testing : PhoneApplicationPage
    {
        SoundEffect Sound1;
        SoundEffect Sound2;
		public Testing()
		
        {
        	InitializeComponent();
	   // Load the sound file
        StreamResourceInfo Sound1 = Application.GetResourceStream(new Uri("Assets/sound1.mp3", UriKind.Relative));		
		
		StreamResourceInfo Sound2 = Application.GetResourceStream(new Uri("Assets/sound1.mp3", UriKind.Relative));
        
		Sound1 = SoundEffect.FromStream(Sound1.Stream);
		Sound2 = SoundEffect.FromStream(Sound2.Stream);
        Microsoft.Xna.Framework.FrameworkDispatcher.Update();
         
        }
		private void Sound1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			Sound1.Play();
			Sound2.Play();
		}
    }
