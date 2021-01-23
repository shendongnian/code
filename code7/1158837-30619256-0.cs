    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace PasswordTextbox
    {
    
        public class PasswordTextBox : TextBox
        {
            private readonly Timer timer;
            private Char[] adminPassword = new Char[16];
            private readonly char DecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0];
            private int m_iCaretPosition = 0;
            private bool canEdit = true;
    
            /// <summary>
            /// 
            /// </summary>
            public PasswordTextBox()
            {
                timer = new Timer { Interval = 200 };
                timer.Tick += timer_Tick;
            }
    
            /// <summary>
            /// 
            /// </summary>
            public string AdminPassword
            {
                get
                {
                    return new string(adminPassword).Trim('\0').Replace("\0", "");
                }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnTextChanged(EventArgs e)
            {
                if (canEdit)
                {
                    base.OnTextChanged(e);
                    txtInput_TextChanged(this, e);
                }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void txtInput_TextChanged(object sender, EventArgs e)
            {
                HidePasswordCharacters();
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);
                m_iCaretPosition = this.GetCharIndexFromPosition(e.Location);
            }
    
            /// <summary>
            /// 
            /// </summary>
            private void HidePasswordCharacters()
            {
                int num = this.Text.Count();
    
                if (num > 1)
                {
                    StringBuilder s = new StringBuilder(this.Text);
                    s[num - 2] = '*';
                    this.Text = s.ToString();
                    this.SelectionStart = num;
                    m_iCaretPosition = num;
                    timer.Enabled = true;
                }
            }
    
            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);
                if (e.KeyCode == Keys.Delete)
                {
                    canEdit = false;
                    DeleteSelectedCharacters(this, e.KeyCode);
                }
            }
    
            /// <summary>
            /// Windows Timer elapsed eventhandler 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void timer_Tick(object sender, EventArgs e)
            {
                timer.Enabled = false;
                int num = this.Text.Count();
    
                if (num > 1)
                {
                    StringBuilder s = new StringBuilder(this.Text);
                    s[num - 1] = '*';
                    this.Invoke(new Action(() =>
                    {
                        this.Text = s.ToString();
                        this.SelectionStart = num;
                        m_iCaretPosition = num;
                    }));
                }
            }
    
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                base.OnKeyPress(e);
    
                int selectionStart = this.SelectionStart;
                int length = this.TextLength;
                int selectedChars = this.SelectionLength;
                canEdit = false;
    
                if (selectedChars == length)
                {
                    /*
                     * Means complete text selected so clear it before using it
                     */
                    ClearCharBufferPlusTextBox();
                }
    
                Keys eModified = (Keys)e.KeyChar;
    
                if (e.KeyChar == DecimalSeparator)
                {
                    e.Handled = true;
                }
                if ((Keys.Delete != eModified) && (Keys.Back != eModified))
                {
                    if (Keys.Space != eModified)
                    {
                        if (e.KeyChar != '-')
                        {
                            if (!char.IsLetterOrDigit(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                adminPassword = new string(adminPassword).Insert(selectionStart, e.KeyChar.ToString()).ToCharArray();
                            }
                        }
                    }
                    else
                    {
                        if (this.TextLength == 0)
                        {
                            e.Handled = true;
                            Array.Clear(adminPassword, 0, adminPassword.Length);
                        }
                    }
                }
                else if ((Keys.Back == eModified) || (Keys.Delete == eModified))
                {
                    DeleteSelectedCharacters(this, eModified);
                }
    
                /*
                 * Replace the characters with '*'
                 */
                HidePasswordCharacters();
    
                canEdit = true;
            }
    
            /// <summary>
            /// Deletes the specific characters in the char array based on the key press action
            /// </summary>
            /// <param name="sender"></param>
            private void DeleteSelectedCharacters(object sender, Keys key)
            {
                int selectionStart = this.SelectionStart;
                int length = this.TextLength;
                int selectedChars = this.SelectionLength;
    
                if (selectedChars == length)
                {
                    ClearCharBufferPlusTextBox();
                    return;
                }
    
                if (selectedChars > 0)
                {
                    int i = selectionStart;
                    this.Text.Remove(selectionStart, selectedChars);
                    adminPassword = new string(adminPassword).Remove(selectionStart, selectedChars).ToCharArray();
                }
                else
                {
                    /*
                     * Basically this portion of code is to handle the condition 
                     * when the cursor is placed at the start or in the end 
                     */
                    if (selectionStart == 0)
                    {
                        /*
                        * Cursor in the beginning, before the first character 
                        * Delete the character only when Del is pressed, No action when Back key is pressed
                        */
                        if (key == Keys.Delete)
                        {
                            adminPassword = new string(adminPassword).Remove(0, 1).ToCharArray();
                        }
                    }
                    else if (selectionStart > 0 && selectionStart < length)
                    {
                        /*
                        * Cursor position anywhere in between 
                        * Backspace and Delete have the same effect
                        */
                        if (key == Keys.Back || key == Keys.Delete)
                        {
                            adminPassword = new string(adminPassword).Remove(selectionStart, 1).ToCharArray();
                        }
                    }
                    else if (selectionStart == length)
                    {
                        /*
                        * Cursor at the end, after the last character 
                        * Delete the character only when Back key is pressed, No action when Delete key is pressed
                        */
                        if (key == Keys.Back)
                        {
                            adminPassword = new string(adminPassword).Remove(selectionStart - 1, 1).ToCharArray();
                        }
                    }
                }
    
                this.Select((selectionStart > this.Text.Length ? this.Text.Length : selectionStart), 0);
    
            }
    
            private void ClearCharBufferPlusTextBox()
            {
                Array.Clear(adminPassword, 0, adminPassword.Length);
                this.Clear();
            }
        }
    }
