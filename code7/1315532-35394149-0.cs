    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class CreateButtons
    {
        /// <summary>
        /// Size to create each button
        /// </summary>
        /// <returns></returns>
        public Size ButtonSize { get; set; }
        /// <summary>
        /// Provides a reference to your buttons
        /// </summary>
        /// <returns></returns>
        public List<Button> Buttons { get; set; }
        /// <summary>
        /// base name of buttone e.g. btn, cmd etc.
        /// </summary>
        /// <returns></returns>
        public string ButtonBaseName { get; set; }
        /// <summary>
        /// Used to spread out buttons
        /// </summary>
        /// <returns></returns>
        public int Base { get; set; }
        public int BaseAddition { get; set; }
        /// <summary>
        /// Count of buttons
        /// </summary>
        /// <returns></returns>
        public int ButtonCount { get; set; }
        /// <summary>
        /// control to place buttons onto
        /// </summary>
        /// <returns></returns>
        public Control ParentControl { get; set; }
        public CreateButtons(string BaseName)
        {
            this.ButtonBaseName = BaseName;
        }
        /// <summary>
        /// Create single button and add it to the list of buttons property
        /// </summary>
        /// <param name="item"></param>
        public void CreateSingleButton(string item)
        {
            if (Buttons == null)
            {
                Buttons = new List<Button>();
            }
            Button b = new Button
            {
                Name = string.Concat(ButtonBaseName, item),
                Text = item,
                Size = ButtonSize,
                Location = new Point(25, this.Base),
                Parent = ParentControl,
                Visible = true
            };
    
            // wire up an event or have an event it gets wired too
            b.Click += (object s, EventArgs e) =>
            {
                //Button tb = (Button)s;
                //MessageBox.Show(tb.Text);
            };
    
            this.ParentControl.Controls.Add(b);
            Buttons.Add(b);
            Base += BaseAddition;
        }
    }
