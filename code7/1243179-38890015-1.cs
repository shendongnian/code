    My_TextBox.TextChanged += (sender, e) =>
                     {
                         if(My_TextBox.LineCount > My_MaxLines)
                         {
                             My_TextBox.MaxLength = My_TextBox.Text.Length;
                         }
                         else
                         {
                             My_TextBox.MaxLength = My_Defined_MaxTextLength;
                         }
                     };
