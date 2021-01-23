    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Current joystick position
        /// </summary>
        Vector m_vtJoystickPos = new Vector();
        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            double fJoystickRadius = Joystick.Height * 0.5;
            //Make coords related to the center
            Vector vtJoystickPos = e.GetPosition(Joystick) - 
                new Point(fJoystickRadius, fJoystickRadius);
            //Normalize coords
            vtJoystickPos /= fJoystickRadius;
            //Limit R [0; 1]
            if (vtJoystickPos.Length > 1.0)
                vtJoystickPos.Normalize();
            XMousePos.Text = vtJoystickPos.X.ToString();
            YMousePos.Text = vtJoystickPos.Y.ToString();
            //Polar coord system
            //double fTheta = Math.Atan2(vtJoystickPos.Y, vtJoystickPos.X);    //knob x,y,r, and theta
            //XPolPos.Text = fTheta.ToString(); //Angle
            //YPolPos.Text = vtJoystickPos.Length.ToString(); //Radius
            if (e.LeftButton == MouseButtonState.Pressed)
            {                                
                m_vtJoystickPos = vtJoystickPos;
                double fKnobRadius = Knob.Width * 0.5;
                Canvas.SetLeft(Knob, Canvas.GetLeft(Joystick) + 
                    vtJoystickPos.X * fJoystickRadius + fJoystickRadius - fKnobRadius);
                Canvas.SetTop(Knob, Canvas.GetTop(Joystick) +
                    vtJoystickPos.Y * fJoystickRadius + fJoystickRadius - fKnobRadius);
            }
        }
    }
