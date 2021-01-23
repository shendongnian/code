    public class MyProgressBar : ProgressBar {
        static MyProgressBar() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (MyProgressBar), new FrameworkPropertyMetadata(typeof (MyProgressBar)));
        }
    }
