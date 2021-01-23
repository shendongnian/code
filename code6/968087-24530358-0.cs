     public partial class TearOffWindow : MetroWindow
        {
            public TearOffWindow()
            {
                InitializeComponent();
                SourceInitialized += (s, a) => this.HideMinimizeButtons();
            }
        }
