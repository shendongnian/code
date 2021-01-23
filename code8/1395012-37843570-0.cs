        using System;
        using System.Collections.Generic;
        using System.Drawing;
        using System.IO;
        using System.Text;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            /// <summary>
            /// The collection of textboxes that need to be added to the form.
            /// </summary>
            private readonly IList<TextBox> inputBoxCollection;
    
            /// <summary>
            /// The name of the file to save the content to.
            /// </summary>
            private const string Filename = "textbox-text.txt";
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Form1"/> class.
            /// </summary>
            public Form1()
            {
                this.InitializeComponent();
                this.inputBoxCollection = new List<TextBox>();
                for (var i = 0; i < 10; i++)
                {
                    this.inputBoxCollection.Add(new TextBox { Location = new Point(0, i*25) });
                }
            }
    
            /// <summary>
            /// Handles the Load event of the Form1 control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void Form1_Load(object sender, EventArgs e)
            {
                var retrievedStrings = File.ReadAllLines(Filename);
                var index = 0;
                foreach (var textBox in this.inputBoxCollection)
                {
                    if (index <= retrievedStrings.Length - 1)
                    {
                        textBox.Text = retrievedStrings[index++];
                    }
                    
                    this.Controls.Add(textBox);
                }
            }
    
            /// <summary>
            /// Handles the Click event of the saveButton control. When pressed, the
            /// content of all the textboxes are stored in a file called textbox-text.txt.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void saveButton_Click(object sender, EventArgs e)
            {
                var builder = new StringBuilder();
                foreach (var textBox in this.inputBoxCollection)
                {
                    builder.AppendLine(textBox.Text);
                }
    
                File.WriteAllText(Filename, builder.ToString());
            }
        }
    }
