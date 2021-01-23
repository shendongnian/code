    My_TextBox.TextChanged += (sender, e) =>
                     {
                         if(My_TextBox.LineCount > MaxLines)
                         {
                             My_TextBox.MaxLength = My_TextBox.Text.Length;
                         }
                         else
                         {
                             My_TextBox.MaxLength = MyDefined_MaxTextLength;
                         }
                     };
