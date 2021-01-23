    public class TextBoxStreamWriter : TextWriter
    {
        private readonly RichTextBox richTextBox;
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxStreamWriter"/> class.
        /// </summary>
        /// <param name="richTextBox">The richTextBox.</param>
        public TextBoxStreamWriter(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
        }
        /// <summary>
        /// Writes a character to the text stream.
        /// </summary>
        /// <param name="value">The character to write to the text stream.</param>
        /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        ///   
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
        public override void Write(char value)
        {
            if (this.richTextBox.Parent.InvokeRequired)
            {
                Action<char> action = Write;
                this.richTextBox.Parent.Invoke(action, value);
            }
            else
            {
                base.Write(value);
                this.richTextBox.AppendText(value.ToString());
                this.richTextBox.ScrollToCaret();
            }
        }
        /// <summary>
        /// Writes out a formatted string, using the same semantics as 
        /// <see cref="M:System.String.Format(System.String,System.Object)"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arg0">An object to write into the formatted string.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="format"/> is null. </exception>
        ///   
        /// <exception cref="T:System.ObjectDisposedException">The 
        /// <see cref="T:System.IO.TextWriter"/> is closed. </exception>
        ///   
        /// <exception cref="T:System.IO.IOException">An I/O error occurs. 
        /// </exception>
        ///   
        /// <exception cref="T:System.FormatException">The format specification
        /// in format is invalid.-or- The number indicating an argument to be
        /// formatted is less than zero, or larger than or equal to the number
        /// of provided objects to be formatted. </exception>
        public override void Write(string format, object arg0)
        {
            if (this.richTextBox.Parent.InvokeRequired)
            {
                Action<string, object> action = Write;
                this.richTextBox.Parent.Invoke(action, format, arg0);
            }
            else
            {
                base.Write(format, arg0);
                this.richTextBox.AppendText(string.Format(format, arg0));
                this.richTextBox.ScrollToCaret();
            }
        }
        
        /// <summary>
        /// When overridden in a derived class, returns the <see cref="T:System.Text.Encoding"/> in which the richTextBox is written.
        /// </summary>
        /// <returns>The Encoding in which the richTextBox is written.</returns>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
