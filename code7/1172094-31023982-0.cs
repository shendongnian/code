    public string getplaintext(string rtftext)
         {  
            string plainText="";
           //Create the RichTextBox. (Requires a reference   to System.Windows.Forms.dll.)
           using(System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox());
           {
                 // Convert the RTF to plain text.
                 rtBox.Rtf = rtftext;
                 plainText = rtBox.Text;
                
               // Now just remove the new line constants
               plainText = plainText.Replace("\r\n", ",");
                
              // Output plain text to file, encoded as UTF-8.
                          
             }
              return plainText;
          }
