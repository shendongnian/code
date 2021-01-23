    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    namespace CustomButton
    {
        public partial class NeatButton : Control
        {
            //Some globals
            private bool _Pressed = false;
            private bool _Activated = false;
            //you will want to put your code for clicking checkboxes in the Mouse overrides. The OnPaint override is where you decide how the boxes look.
            protected override void OnMouseDown(MouseEventArgs e){...}
            protected override void OnMouseUp(MouseEventArgs e){...}
            protected override void OnPaint(PaintEventArgs pe){...}
            //You will want some propeties
         public new string Text
        {
            get { return base.Text; }
            set
            {
                if (value == base.Text)
                    return;
                base.Text = value;
                Invalidate(); //Keeps text showing changes in real time
            }
        }
        /// <summary>
        /// Works with Pressed to determine if the button should do something  when clicked. **Use a property like this for the checkboxes**
        /// </summary>
        private bool Activated
        {
            get { return _Activated; }
            set
            {
                if (value == _Activated)
                    return;
                _Activated = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Works with Activated to determine if the button should do something when clicked 
        /// </summary>
        private bool Pressed
        {
            get { return _Pressed; }
            set
            {
                if (value == _Pressed)
                    return;
                _Pressed = value;
                Invalidate();
            }
        }
